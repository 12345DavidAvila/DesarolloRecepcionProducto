using System;
using System.Collections.Generic;
using System.Text;

namespace DesarolloRecepcionProducto.Modelos
{
    public class Login
    {
        public int cedula { get; set; }
        public string  usuario { get; set; }

        public string pass { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public string rol { get; set; }
        public string estado { get; set; }
    }
}
