namespace PQRS.Dto.dtos
{
    using System;
    using System.Text;
    using enums;
    using helpers;
    public class Queja : Solicitud
    {
        private int idQueja;
        private int idSupervisor;
        private RemuneracionType idTipoRemuneracion;

        public Queja(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, int idQueja, int idSupervisor, RemuneracionType idTipoRemuneracion) : base(area, idCliente, servicio, tipoSolicitud)
        {
            this.idQueja = idQueja;
            this.idSupervisor = idSupervisor;
            this.idTipoRemuneracion = idTipoRemuneracion;
        }

        public int IdQueja
        {
            get { return idQueja; }
            set { idQueja = value; }
        }
        public int IdSupervisor
        {
            get { return idSupervisor; }
            set { idSupervisor = value; }
        }
        public RemuneracionType IdTipoRemuneracion
        {
            get { return idTipoRemuneracion; }
            set { idTipoRemuneracion = value; }
        }

        public override bool Validar()
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (idTipoRemuneracion == 0)
            {
                sbError.AppendLine("El Campo tipo de remuneraciòn es obligatirio");
            }
            if (idSupervisor == 0)
            {
                sbError.AppendLine("El campo supervisor es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Registrar()
        {
            this.IdQueja = IdGenerator.QuejaID;
            this.Validar();
            //Almacena
            return true;
        }
    }
}