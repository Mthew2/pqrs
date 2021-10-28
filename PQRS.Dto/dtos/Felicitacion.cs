using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.dtos
{
    using enums;
    using PQRS.Dto.helpers;

    public class Felicitacion: Solicitud
    {
        private int idFelicitacion;
        private string descripcion;

        public Felicitacion(AreaType area, int idCliente, ServicioType servicio, SolicitudType tipoSolicitud, string descripcion) : base(area, idCliente, servicio, tipoSolicitud)
        {
            this.descripcion = descripcion;
        }

        public int IdFelicitacion
        {
            get { return idFelicitacion; }
            set { idFelicitacion = value; }
        }


        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public override bool Validar()
        {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (String.IsNullOrEmpty(descripcion))
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
            this.idFelicitacion = IdGenerator.FelicitacionID;
            this.Validar();
            //Almacena
            return true;
        }
    }
}
