using Newtonsoft.Json;

namespace Webmotors.Mediator.Api.Client
{
    public class ApiClient
    {
        private RestWebmotors vRestWebmotors;
        public ApiClient(string pUrl, EndPoints pResource)
        {
            vRestWebmotors = new RestWebmotors(pUrl+ pResource.Value);            
        }

        public O Get<O>(int pPage)
        {           
            var vApiRequest = new RequestWebmotors(pPage);            
            vApiRequest.Method = RestSharp.Method.Get;
            var resposta = vRestWebmotors.Execute(vApiRequest);
            return JsonConvert.DeserializeObject<O>(resposta.Content);
        }
    }
}
