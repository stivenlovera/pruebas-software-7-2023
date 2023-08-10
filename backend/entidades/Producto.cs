using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.entidades
{
    public class Producto : Common
    {
        public string Nombre { get; set; }
        public string CategoriaId { get; set; }
    }
}