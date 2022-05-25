using System;
using System.Collections.Generic;
using System.Text;

namespace DesarolloRecepcionProducto.Modelos
{
    public class ProductoModel
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string cantidad;

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private string precioCompra;

        public string PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }
        private string precioVenta;

        public string PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }

        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private string ubicacion;

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }

}
