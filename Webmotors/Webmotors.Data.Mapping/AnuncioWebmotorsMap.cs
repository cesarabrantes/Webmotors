using FluentNHibernate.Mapping;
using Webmotors.Domain.Models;

namespace Webmotors.Data.Mapping
{
    public class AnuncioWebmotorsMap : ClassMap<AnuncioWebmotors>
    {
        public AnuncioWebmotorsMap()
        {
            Table("tb_AnuncioWebmotors");
            Id(p => p.Id).Column("").Not.Nullable();
            Map(p => p.Marca).Column("marca").Length(45).Not.Nullable();
            Map(p => p.Modelo).Column("modelo").Length(45).Not.Nullable();
            Map(p => p.Versao).Column("versao").Length(45).Not.Nullable();
            Map(p => p.Ano).Column("ano").Not.Nullable();
            Map(p => p.Quilometragem).Column("quilometragem").Not.Nullable();            
            Map(p => p.Observacao).Column("observacao").CustomSqlType("text").Not.Nullable();            
        }
    }
}
