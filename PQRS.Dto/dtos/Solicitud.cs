using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto
{
    public abstract class Solicitud
    {
        private int area;

        public int Area
        {
            get { return area; }
            set { area = value; }
        }

        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }


    }
}
