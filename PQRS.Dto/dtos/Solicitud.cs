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
            this.error = string.Empty;
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

        public abstract bool Registrar();
        public abstract bool Consultar();

        public virtual bool Validar()
        {
            this.Error = string.Empty;
            StringBuilder sbError = new StringBuilder("");
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
            return String.IsNullOrEmpty(this.error);
        }
    }
}
