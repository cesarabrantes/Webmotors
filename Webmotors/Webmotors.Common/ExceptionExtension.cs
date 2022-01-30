using System;

namespace Webmotors.Common
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// Recupera as Exceções Internas para armazenamento utilização em Log de Erros
        /// </summary>
        /// <param name="ex">Exception Gerada</param>
        /// <returns></returns>
        public static Exception GetInnerException(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex;
            else
                return GetInnerException(ex.InnerException);
        }       
    }
}
