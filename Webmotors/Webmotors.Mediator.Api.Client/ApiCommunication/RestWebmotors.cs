using RestSharp;
using System;
using System.Net;

namespace Webmotors.Mediator.Api.Client
{
    public class RestWebmotors : RestSharp.RestClient
    {
        public RestWebmotors(string url) : base(url)
        {
            //base.BaseUrl = new Uri(url);
        }

        public RestResponse Execute(RestRequest request)
        {
            var executed = base.ExecuteAsync(request).Result;
            
            var msg = $"Tivemos um problema ao acessar a API. O status retornado é {Convert.ToInt32(executed.StatusCode)} {executed.StatusDescription} {executed.ErrorMessage}";
            switch (executed.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NoContent:
                    return executed;

                //422 duplicidade de sku
                case (HttpStatusCode)422:
                    throw new Exception(executed.Content);
                //return executed;

                case HttpStatusCode.Unauthorized:
                    msg = string.IsNullOrEmpty(executed.Content) ? "Requisição não autorizada" : executed.Content;
                    throw new Exception(msg);

                case HttpStatusCode.NotFound:
                    msg = string.IsNullOrEmpty(executed.Content) ? "Método não encontrado" : executed.Content;
                    throw new Exception(msg);

                case HttpStatusCode.InternalServerError:
                    msg = string.IsNullOrEmpty(executed.Content) ? "Servidor retornou um erro interno" : executed.Content;
                    throw new Exception(msg);

                case HttpStatusCode.GatewayTimeout:
                    msg = string.IsNullOrEmpty(executed.Content) ? "Servidor está demorando para responder q requisição" : executed.Content;
                    throw new Exception(msg);

                case HttpStatusCode.BadGateway:
                    msg = string.IsNullOrEmpty(executed.Content) ? "Ocorreu um erro na requisição para o servidor" : executed.Content;
                    throw new Exception(msg);

                default:
                    msg = string.IsNullOrEmpty(executed.Content) ? msg : executed.Content;
                    throw new Exception(msg);
            }
        }
    }


}
