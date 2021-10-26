namespace PQRS.Dto
{
    using System;
    using System.Text;
    using enums;

    public abstract class Solicitud
    {
        private AreaType area;
        private int idCliente;
        private ServicioType servicio;
        private SolicitudType tipoSolicitud;
        private DateTime fecha;
        private string error;

        public Solicitud(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud) {
            this.area = area;
            this.idCliente = idCliente;
            this.servicio = servicio;
            this.tipoSolicitud = tipoSolicitud;
            this.fecha = DateTime.Now;
        }

        public AreaType Area
        {
            get { return area; }
            set { area = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public ServicioType Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        public SolicitudType TipoSolicitud
        {
            get { return tipoSolicitud; }
            set { tipoSolicitud = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Error
        {
            get { return error; }
            protected set { error = value; }
        }

        public virtual bool Registrar()
        {
            if (!this.Validar())
            {
                return false;
            }
            //Almacena en plugin de Excel
            return true;
        }

        public bool Consultar() { 
            //Consulta en libro de excelpor id Solicitud
            return true; 
        }

        public virtual bool Validar()
        {
            StringBuilder sbError = new StringBuilder();
            if (this.area == 0)
            {
                sbError.AppendLine("El campo Area es oblogatirio");
            }
            if (this.IdCliente == 0)
            {
                sbError.AppendLine("El campo Cliente es oblogatirio");
            }
            if (this.servicio == 0)
            {
                sbError.AppendLine("El campo Servicio es oblogatirio");
            }
            if (this.tipoSolicitud == 0)
            {
                sbError.AppendLine("El campo Tipo de Solicitud es oblogatirio");
            }
            this.error = sbError.ToString();
            return this.error.Length == 0;
        }
    }
}
