using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsaioBack.DataTransfer
{
    public class EnsaioInserirRequest
    {
        public string? Lider { get; set; }
        public string? Cancoes { get; set; }
        public string? Integrantes { get; set; }
        public string? Data { get; set; }
        public string?Horario { get; set; }

    }
}