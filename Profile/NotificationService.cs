using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Profile {
    public class NotificationService : INotificationService {
        readonly PublisherClient publisher;

        private readonly IConfiguration configuration;

        public NotificationService (IConfiguration configuration, PublisherClient publisher) {
            this.configuration = configuration;
            this.publisher = publisher;

        }

        public async Task<HttpStatusCode> Notify<T> (T Message) where T : HttpContent {
            using HttpClient httpClient = new HttpClient () { BaseAddress = new Uri (configuration.GetSection ("Services:NotificationUri").Value) };
            HttpResponseMessage response = await httpClient.PostAsync ("/api/notification", Message);
            response = response.EnsureSuccessStatusCode ();
            return response.StatusCode;
        }

        public async Task Create (Entityframework.IEvent Profile) {
            var message = JsonConvert.SerializeObject (Profile);
            var pubsubMessage = new PubsubMessage () {
                Data = ByteString.CopyFromUtf8 (message)
            };
            // pubsubMessage.Attributes["token"] = _options.VerificationToken;
            await publisher.PublishAsync (pubsubMessage);
        }
    }
}