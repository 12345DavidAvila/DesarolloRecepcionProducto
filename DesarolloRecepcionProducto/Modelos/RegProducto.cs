using System;
using System.Collections.Generic;
using System.Text;

namespace DesarolloRecepcionProducto.Modelos
{
    public  class RegProducto
    {
        public string serie { get; set; }
        public string nombre { get; set; }
        public string cantidad { get; set; }

        public string precioCompra { get; set; }
        public string precioVenta { get; set; }
        public string categoria { get; set; }

        public string marca { get; set; }
        public string ubicacion { get; set; }
        public string estado { get; set; }
    }
}
