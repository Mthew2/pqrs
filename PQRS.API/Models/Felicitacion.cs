using System;
using System.Text;

namespace PQRS.API.Models
{   
    using helpers;

    public class Felicitacion: Solicitud
    {
        private int intIdFelicitacion;
        private string strDescripcion;

        public Felicitacion() { }

        public int IdFelicitacion
        {
            get { return intIdFelicitacion; }
            set { intIdFelicitacion = value; }
        }


        public string Descripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }

        public override bool Validar()
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (String.IsNullOrEmpty(strDescripcion))
            {
                sbError.AppendLine("El Campo descripcion es obligatirio");
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
            this.intIdFelicitacion = IdGenerator.FelicitacionID;
            this.Validar();
            //Almacena
            return true;
        }
    }
}
