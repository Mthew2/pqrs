using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PQRS.API.Models
{
    using Persistance;
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
            if (String.IsNullOrEmpty(strDescripcion))
            {
                sbError.AppendLine("El Campo descripcion es obligatirio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }

        public override bool Consultar()
        {
            try
            {
                ExcelPersistance persistance = new ExcelPersistance();
                DataTable dt = persistance.GetData(SolicitudType.FELICITACION);

                if (dt.Rows.Count == 0)
                {
                    this.Error = "El Arachivo no contiene informnación";
                    return false;
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString() == this.intIdFelicitacion.ToString())
                    {
                        this.Area = Convert.ToInt32(dt.Rows[i]["Area"]);
                        this.IdCliente = Convert.ToInt32(dt.Rows[i]["IdCliente"]);
                        this.Servicio = Convert.ToInt32(dt.Rows[i]["Servicio"]);
                        this.TipoSoli = Convert.ToInt32(dt.Rows[i]["TipoSoli"]);
                        this.Fecha = Convert.ToString(dt.Rows[i]["Fecha"]);
                        this.intIdFelicitacion = Convert.ToInt32(dt.Rows[i]["IdFelicitacion"]);
                        this.strDescripcion = Convert.ToString(dt.Rows[i]["Descripcion"]);
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
                this.IdFelicitacion = IdGenerator.FelicitacionID;
                ExcelPersistance persistance = new ExcelPersistance();

                Dictionary<int, int> key = new Dictionary<int, int>();
                key.Add(6, this.intIdFelicitacion);

                Dictionary<int, string> values = new Dictionary<int, string>();
                values.Add(1, this.Area.ToString());
                values.Add(2, this.IdCliente.ToString());
                values.Add(3, this.Servicio.ToString());
                values.Add(4, this.TipoSoli.ToString());
                values.Add(5, this.Fecha);
                values.Add(6, this.intIdFelicitacion.ToString());
                values.Add(7, this.strDescripcion);

                if (persistance.SaveData(SolicitudType.FELICITACION, key, values))
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
