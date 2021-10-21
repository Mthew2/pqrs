using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    public class Peticion: Solicitud
    {
        private int idPeticion;

        public int Idpeticion
        {
            get { return idPeticion; }
            set { idPeticion = value; }
        }

    }
}
