using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PQRS.API.Models
{
    using Persistance;
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

        private bool Validar()
        {
            this.Error = string.Empty;
            StringBuilder sbError = new StringBuilder("");
            if (this.Area == 0)
            {
                sbError.AppendLine("El campo Area es oblogatirio");
            }
            if (this.IdCliente == 0)
            {
                sbError.AppendLine("El campo Cliente es oblogatirio");
            }
            if (this.Servicio == 0)
            {
                sbError.AppendLine("El campo intServicio es oblogatirio");
            }
            if (this.TipoSoli == 0)
            {
                sbError.AppendLine("El campo Tipo de Solicitud es oblogatirio");
            }
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
            try
            {
                ExcelPersistance persistance = new ExcelPersistance();
                DataTable dt = persistance.GetData(SolicitudType.QUEJA);

                if (dt.Rows.Count == 0)
                {
                    this.Error = "El Arachivo no contiene informnación";
                    return false;
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString() == this.intIdQueja.ToString())
                    {
                        this.Area = Convert.ToInt32(dt.Rows[i]["Area"]);
                        this.IdCliente = Convert.ToInt32(dt.Rows[i]["IdCliente"]);
                        this.Servicio = Convert.ToInt32(dt.Rows[i]["Servicio"]);
                        this.TipoSoli = Convert.ToInt32(dt.Rows[i]["TipoSoli"]);
                        this.Fecha = Convert.ToString(dt.Rows[i]["Fecha"]);
                        this.intIdQueja = Convert.ToInt32(dt.Rows[i]["IdQueja"]);
                        this.intIdSupervisor = Convert.ToInt32(dt.Rows[i]["IdSupervisor"]);
                        this.intIdTipoRemuneracion = Convert.ToInt32(dt.Rows[i]["IdTipoResumenaracion"]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                return false;
            }
        }

        public override bool Registrar()
        {
            try
            {
                if (!this.Validar())
                {
                    return false;
                }
                this.IdQueja = IdGenerator.QuejaID;
                ExcelPersistance persistance = new ExcelPersistance();

                Dictionary<int, int> key = new Dictionary<int, int>();
                key.Add(6, this.intIdQueja);

                Dictionary<int, string> values = new Dictionary<int, string>();
                values.Add(1, this.Area.ToString());
                values.Add(2, this.IdCliente.ToString());
                values.Add(3, this.Servicio.ToString());
                values.Add(4, this.TipoSoli.ToString());
                values.Add(5, this.Fecha);
                values.Add(6, this.intIdQueja.ToString());
                values.Add(7, this.intIdSupervisor.ToString());
                values.Add(8, this.intIdTipoRemuneracion.ToString());

                if (persistance.SaveData(SolicitudType.QUEJA, key, values))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                this.Error = ex.Message;
                return false;
            }
        }
    }
}