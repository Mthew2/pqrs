namespace PQRS.Dto.dtos
{
    using enums;
    using helpers;
    using System;
    using System.Text;
    public class Sugerencia: Solicitud
    {
        private int idSugerencia;
        private int tipoSugerencia;
        private string descripcion;

        public Sugerencia(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, int idSugerencia, int tipoSugerencia, string descripcion) : base(area, idCliente, servicio, tipoSolicitud)
        {
            this.idSugerencia = idSugerencia;
            this.tipoSugerencia = tipoSugerencia;
            this.descripcion = descripcion;
        }

        public int IdSugerencia
        {
            get { return idSugerencia; }
            set { idSugerencia = value; }
        }

        public int TipoSugerencia
        {
            get { return tipoSugerencia; }
            set { tipoSugerencia = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Registrar()
        {
            this.idSugerencia = IdGenerator.SugerenciaID;
            this.Validar();
            //Almacena
            return true;
        }

        public override bool Validar() {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (tipoSugerencia == 0)
            {
                sbError.AppendLine("El campo tipo de sugerencia es obligatorio");
            }
            if (String.IsNullOrEmpty(descripcion))
            {
                sbError.AppendLine("El campo descripcion es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
