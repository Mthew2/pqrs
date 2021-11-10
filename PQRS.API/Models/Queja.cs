namespace PQRS.API.Models
{
    using System;
    using System.Text;
    using helpers;
    public class Queja : Solicitud
    {
        private int intIdQueja;
        private int intIdSupervisor;
        private int intIdTipoRemuneracion;

        public Queja()
        {
        }

        public int IdQueja
        {
            get { return intIdQueja; }
            set { intIdQueja = value; }
        }
        public int IdSupervisor
        {
            get { return intIdSupervisor; }
            set { intIdSupervisor = value; }
        }
        public int IdTipoRemuneracion
        {
            get { return intIdTipoRemuneracion; }
            set { intIdTipoRemuneracion = value; }
        }

        public override bool Validar()
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (intIdTipoRemuneracion == 0)
            {
                sbError.AppendLine("El Campo tipo de remuneraciòn es obligatirio");
            }
            if (IdSupervisor == 0)
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