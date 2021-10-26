using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    public class Sugerencia: Solicitud
    {
        private int tipoSugerencia;

        public int TipoSugerencia
        {
            get { return tipoSugerencia; }
            set { tipoSugerencia = value; }
        }


        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public override bool Validar() {
            return true;
        }
    }
}
