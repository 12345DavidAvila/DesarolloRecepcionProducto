using System;
using System.Collections.Generic;
using System.Text;

namespace DesarolloRecepcionProducto.Modelos
{
    public class UsuarioModel
    {
        private string cedula;

        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}

