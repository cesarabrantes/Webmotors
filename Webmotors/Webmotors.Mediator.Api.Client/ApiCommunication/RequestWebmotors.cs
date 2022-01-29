using RestSharp;

namespace Webmotors.Mediator.Api.Client
{
    public class RequestWebmotors : RestRequest
    {
        public RequestWebmotors(int page) : base()
        {
            this.AddQueryParameter("page", page);
        }
    }

}
