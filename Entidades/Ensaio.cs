using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsaioBack.Entidades
{
    public class Ensaio
    {
        public virtual int Id { get; set; }
        public virtual string? Lider { get; set; }
        public virtual string? Cancoes { get; set; }
        public virtual string? Integrantes { get; set; }
        public virtual string? Data { get; set; }
        public virtual string? Horario { get; set; }

    }
}