using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    using enums;
    public class Reclamo: Solicitud
    {
        private ReclamoType idReclamo;

        public ReclamoType IdReclamo
        {
            get { return idReclamo; }
            set { idReclamo = value; }
        }

        private SolucionType idSolicitud;

        public SolucionType IdSolicitud
        {
            get { return idSolicitud; }
            set { idSolicitud = value; }
        }

        private double costo;

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public override bool Validar() {
            return true;
        }
    }
}
