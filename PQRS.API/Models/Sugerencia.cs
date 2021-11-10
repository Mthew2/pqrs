namespace PQRS.API.Models
{
    using helpers;
    using System;
    using System.Text;
    public class Sugerencia : Solicitud
    {
        private int intIdSugerencia;
        private int intTipoSugerencia;
        private string strDescripcion;

        public Sugerencia() { }

        public int IdSugerencia
        {
            get { return intIdSugerencia; }
            set { intIdSugerencia = value; }
        }

        public int TipoSugerencia
        {
            get { return intTipoSugerencia; }
            set { intTipoSugerencia = value; }
        }

        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }

        public override bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override bool Registrar()
        {
            this.intIdSugerencia = IdGenerator.SugerenciaID;
            this.Validar();
            //Almacena
            return true;
        }

        public override bool Validar()
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (intTipoSugerencia == 0)
            {
                sbError.AppendLine("El campo tipo de sugerencia es obligatorio");
            }
            if (String.IsNullOrEmpty(strDescripcion))
            {
                sbError.AppendLine("El campo descripcion es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
