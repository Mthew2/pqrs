namespace PQRS.Dto
{
    using System;
    using System.Text;

    public abstract class Solicitud
    {
        private int intArea;
        private int intIdCliente;
        private int intServicio;
        private int intTipoSoli;
        private string strFecha;
        private string strError;

        public Solicitud() {
            //public Solicitud(int area, int intIdCliente, int intServicio, int intTipoSoli)
            //{
                //this.intArea = area;
                //this.intIdCliente = intIdCliente;
                //this.intServicio = intServicio;
                //this.intTipoSoli = intTipoSoli;
                //this.strFecha = DateTime.Now.ToString();
                //this.strError = string.Empty;
            }

        public int Area
        {
            get { return intArea; }
            set { intArea = value; }
        }

        public int IdCliente
        {
            get { return intIdCliente; }
            set { intIdCliente = value; }
        }

        public int Servicio
        {
            get { return intServicio; }
            set { intServicio = value; }
        }

        public int TipoSoli
        {
            get { return intTipoSoli; }
            set { intTipoSoli = value; }
        }

        public string Fecha
        {
            get { return strFecha; }
            set { strFecha = value; }
        }

        public string Error
        {
            get { return strError; }
            protected set { strError = value; }
        }

        public abstract bool Registrar();
        public abstract bool Consultar();

        public virtual bool Validar()
        {
            this.strError = string.Empty;
            StringBuilder sbstrError = new StringBuilder("");
            if (this.intArea == 0)
            {
                sbstrError.AppendLine("El campo Area es oblogatirio");
            }
            if (this.intIdCliente == 0)
            {
                sbstrError.AppendLine("El campo Cliente es oblogatirio");
            }
            if (this.intServicio == 0)
            {
                sbstrError.AppendLine("El campo intServicio es oblogatirio");
            }
            if (this.intTipoSoli == 0)
            {
                sbstrError.AppendLine("El campo Tipo de Solicitud es oblogatirio");
            }
            this.strError = sbstrError.ToString();
            return String.IsNullOrEmpty(this.strError);
        }
    }
}
