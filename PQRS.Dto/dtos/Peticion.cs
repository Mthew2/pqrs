using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    using enums;
    using PQRS.Dto.helpers;

    public class Peticion: Solicitud
    {

        private int idPeticion;
        private int idSupervisor;

        public Peticion(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, int idPeticion, int idSupervisor) : base(area, idCliente, servicio, tipoSolicitud)
        {
            this.idPeticion = idPeticion;
            this.idSupervisor = idSupervisor;
        }

        public int Idpeticion
        {
            get { return idPeticion; }
            set { idPeticion = value; }
        }

        public int IdSupervisor
        {
            get { return idSupervisor; }
            set { idSupervisor = value; }
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Registrar()
        {
            this.idPeticion = IdGenerator.PeticionID;
            this.Validar();
            //Almacena
            return true;
        }

        public override bool Validar() {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (idSupervisor == 0)
            {
                sbError.AppendLine("El campo supervisor es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
