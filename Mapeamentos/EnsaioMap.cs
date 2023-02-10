using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsaioBack.Entidades;
using FluentNHibernate.Mapping;

namespace EnsaioBack.Mapeamentos
{
    public class EnsaioMap : ClassMap<Ensaio>
    {
        public EnsaioMap()
        {
            Schema("Ensaio");
            Table("Ensaios");
            Id(ensaio => ensaio.Id).Column("id");
            Map(ensaio => ensaio.Lider).Column("lider");
            Map(ensaio => ensaio.Cancoes).Column("cancoes");
            Map(ensaio => ensaio.Integrantes).Column("integrantes");
            Map(ensaio => ensaio.Data).Column("dia");
             Map(ensaio => ensaio.Horario).Column("horario");
        }
    }
}