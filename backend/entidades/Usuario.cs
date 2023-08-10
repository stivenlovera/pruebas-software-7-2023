using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.entidades
{
    public class Usuario : Common
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}