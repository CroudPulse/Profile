using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.PubSub.V1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Profile.Entityframework.EF;

namespace Profile
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });

                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddDbContextPool<CroudPulseDbContext>(opts =>
            {
                opts.UseMySql(Configuration.GetConnectionString("CroudPulseDbContext"));
            });

            services.Configure<PubSubOptions>(
              Configuration.GetSection("Pubsub"));

            services.AddSingleton((provider) =>
            {
                var options = provider.GetService<IOptions<PubSubOptions>>()
                    .Value;
                var logger = provider.GetService<ILogger<Startup>>();
                // CreateTopicAndSubscription(options, logger);
                return PublisherClient.CreateAsync(new TopicName(options.ProjectId
                            , options.TopicId)).Result;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection ();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins); ;
            });
        }

        static void CreateTopicAndSubscription(PubSubOptions options,
           ILogger logger)
        {
            var topicName = new TopicName(options.ProjectId, options.TopicId);
            var publisher = PublisherServiceApiClient.Create();
            try
            {
                publisher.CreateTopic(topicName);
            }
            catch (Grpc.Core.RpcException e)
            when (e.Status.StatusCode == Grpc.Core.StatusCode.AlreadyExists ||
                e.Status.StatusCode == Grpc.Core.StatusCode.PermissionDenied)
            {
                logger.LogWarning(0, e, "Could not create topic {0}", topicName);
            }
            var subscriptionName = new SubscriptionName(
                    options.ProjectId, options.SubscriptionId);
            var pushConfig = new PushConfig()
            {
                PushEndpoint = $"https://{options.ProjectId}.appspot.com/Push"
            };
            var subscriber = SubscriberServiceApiClient.Create();
            try
            {
                subscriber.CreateSubscription(subscriptionName, topicName,
                    pushConfig, 20);
                return;
            }
            catch (Grpc.Core.RpcException e)
            when (e.Status.StatusCode == Grpc.Core.StatusCode.AlreadyExists ||
                e.Status.StatusCode == Grpc.Core.StatusCode.PermissionDenied)
            {
                logger.LogWarning(1, e, "Could not create subscription {0}",
                    subscriptionName);
            }
            try
            {
                subscriber.ModifyPushConfig(subscriptionName, pushConfig);
            }
            catch (Grpc.Core.RpcException e)
            when (e.Status.StatusCode == Grpc.Core.StatusCode.PermissionDenied)
            {
                logger.LogWarning(2, e, "Could not modify subscription {0}",
                    subscriptionName);
            }
        }
    }
}