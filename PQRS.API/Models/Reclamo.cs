namespace PQRS.API.Models
{
    using System;
    using System.Text;
    using helpers;

    public class Reclamo: Solicitud
    {
        private int intIdReclamo;
        private int intIdTipoReclamo;
        private int intIdSolicitud;
        private double costo;

        public Reclamo()
        {
        }
        

        public int IdReclamo
        {
            get { return intIdReclamo; }
            set { intIdReclamo = value; }
        }

        public int IdTipoReclamo
        {
            get { return intIdTipoReclamo; }
            set { intIdTipoReclamo = value; }
        }

        public int IdSolicitud
        {
            get { return intIdSolicitud; }
            set { intIdSolicitud = value; }
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
            this.intIdReclamo = IdGenerator.ReclamoID;
            this.Validar();
            //Almacena
            return true;
        }

        public override bool Validar() 
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (intIdTipoReclamo == 0)
            {
                sbError.AppendLine("El campo tipo reclamo es obligatorio");
            }
            if (intIdSolicitud == 0)
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
