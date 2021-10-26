using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    public class Felicitacion: Solicitud
    {
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
