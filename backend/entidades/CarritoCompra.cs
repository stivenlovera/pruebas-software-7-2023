using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.entidades
{
    public class CarritoCompra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }
}