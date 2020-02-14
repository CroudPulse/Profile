using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Profile
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration configuration;

        public NotificationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<HttpStatusCode> Notify<T>(T Message) where T : HttpContent
        {
            using HttpClient httpClient = new HttpClient() { BaseAddress = new Uri(configuration.GetSection("Services:NotificationUri").Value)  };
            HttpResponseMessage response = await httpClient.PostAsync("/api/notification", Message);
            response = response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    }
}
