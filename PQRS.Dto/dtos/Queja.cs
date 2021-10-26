namespace PQRS.Dto.dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using enums;
    using helpers;
    public class Queja: Solicitud
    {
        private int idQueja;
        private int idSupervisor;
        private RemuneracionType idTipoRemuneracion;

        public Queja(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, int idQueja, int idSupervisor, RemuneracionType idTipoRemuneracion) : base(area, idCliente, servicio, tipoSolicitud) {
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

        public override bool Validar() {
            base.Validar();
            if(idTipoRemuneracion == 0) {
                this.Error = "El Campo tipo de remuneraciòn es obligatirio";
                return false;
            }
            return true;
        }

        public override bool Registrar() {
            this.IdQueja = IdGenerator.QuejaID;
            base.Registrar();
            if (!string.IsNullOrEmpty(this.Error)) {
            }
            return true;
        }
    }
}