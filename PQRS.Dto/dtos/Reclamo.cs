namespace PQRS.Dto.dtos
{
    using System;
    using System.Text;
    using enums;
    using helpers;

    public class Reclamo: Solicitud
    {
        private int idReclamo;
        private ReclamoType idTipoReclamo;
        private SolucionType idSolicitud;
        private double costo;

        public Reclamo(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, int idReclamo, ReclamoType idTipoReclamo, int idSupervisor, SolucionType idSolicitud, double costo) : base(area, idCliente, servicio, tipoSolicitud)
        {
            this.idReclamo = idReclamo;
            this.idTipoReclamo = idTipoReclamo;
            this.idSolicitud = idSolicitud;
            this.costo = costo;
        }
        

        public int IdReclamo
        {
            get { return idReclamo; }
            set { idReclamo = value; }
        }

        public ReclamoType IdTipoReclamo
        {
            get { return idTipoReclamo; }
            set { idTipoReclamo = value; }
        }

        public SolucionType IdSolicitud
        {
            get { return idSolicitud; }
            set { idSolicitud = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Registrar()
        {
            this.idReclamo = IdGenerator.ReclamoID;
            this.Validar();
            //Almacena
            return true;
        }

        public override bool Validar() 
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (idTipoReclamo == 0)
            {
                sbError.AppendLine("El campo tipo reclamo es obligatorio");
            }
            if (idSolicitud == 0)
            {
                sbError.AppendLine("El campo solicitud es obligatorio");
            }
            if (costo == 0)
            {
                sbError.AppendLine("El campo costo es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
