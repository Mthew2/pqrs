using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PQRS.API.Models
{
    using Persistance;
    using helpers;

    public abstract class Solicitud
    {
        private int intArea;
        private int intIdCliente;
        private int intServicio;
        private int intTipoSoli;
        private string strFecha;
        private string strError;

        public Solicitud() {}

        public int Area
        {
            get { return intArea; }
            set { intArea = value; }
        }

        public int IdCliente
        {
            get { return intIdCliente; }
            set { intIdCliente = value; }
        }

        public int Servicio
        {
            get { return intServicio; }
            set { intServicio = value; }
        }

        public int TipoSoli
        {
            get { return intTipoSoli; }
            set { intTipoSoli = value; }
        }

        public string Fecha
        {
            get { return strFecha; }
            set { strFecha = value; }
        }

        public string Error
        {
            get { return strError; }
            protected set { strError = value; }
        }

        public abstract bool Registrar();
        public abstract bool Consultar();

    }
}
