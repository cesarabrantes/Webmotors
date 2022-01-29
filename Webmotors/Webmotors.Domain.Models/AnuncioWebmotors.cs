using System;

namespace Webmotors.Domain.Models
{
    public class AnuncioWebmotors
    {
        public virtual int Id { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Modelo { get; set; }
        public virtual string Versao { get; set; }
        public virtual int Ano { get; set; }
        public virtual int Quilometragem { get; set; }
        public virtual string Observacao { get; set; }
    }
}
