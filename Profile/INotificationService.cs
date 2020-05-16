using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Profile {
    public interface INotificationService {
        Task<HttpStatusCode> Notify<T> (T Message) where T : HttpContent;
        Task Create (Entityframework.IEvent Profile);
    }
}