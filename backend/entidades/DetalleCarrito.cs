using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.entidades
{
    public class DetalleCarrito : Common
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int CarritoCompraId { get; set; }
    }

}