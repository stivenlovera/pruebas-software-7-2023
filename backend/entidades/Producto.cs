using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.entidades
{
    public class Producto : Common
    {
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
    }
}