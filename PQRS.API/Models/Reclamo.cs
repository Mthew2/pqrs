using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PQRS.API.Models
{
    using Persistance;
    using helpers;

    public class Reclamo: Solicitud
    {
        private int intIdReclamo;
        private int intIdTipoReclamo;
        private int intIdSolucion;
        private double dblCosto;

        public Reclamo()
        {
        }
        

        public int IdReclamo
        {
            get { return intIdReclamo; }
            set { intIdReclamo = value; }
        }

        public int IdTipoReclamo
        {
            get { return intIdTipoReclamo; }
            set { intIdTipoReclamo = value; }
        }

        public int IdSolucion
        {
            get { return intIdSolucion; }
            set { intIdSolucion = value; }
        }

        public double Costo
        {
            get { return dblCosto; }
            set { dblCosto = value; }
        }

        public override bool Consultar()
        {
            try
            {
                ExcelPersistance persistance = new ExcelPersistance();
                DataTable dt = persistance.GetData(SolicitudType.RECLAMO);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("El Arachivo no contiene informnación");
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString().Trim().Equals(this.intIdReclamo.ToString()))
                    {
                        this.Area = Convert.ToInt32(dt.Rows[i]["Area"]);
                        this.IdCliente = Convert.ToInt32(dt.Rows[i]["IdCliente"]);
                        this.Servicio = Convert.ToInt32(dt.Rows[i]["Servicio"]);
                        this.TipoSoli = Convert.ToInt32(dt.Rows[i]["TipoSoli"]);
                        this.Fecha = Convert.ToString(dt.Rows[i]["Fecha"]);
                        this.intIdReclamo = Convert.ToInt32(dt.Rows[i]["IdReclamo"]);
                        this.intIdSolucion = Convert.ToInt32(dt.Rows[i]["IdSolucion"]);
                        this.dblCosto = Convert.ToDouble(dt.Rows[i]["Costo"]);
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
                this.intIdReclamo = IdGenerator.ReclamoID;
                ExcelPersistance persistance = new ExcelPersistance();

                Dictionary<int, int> key = new Dictionary<int, int>();
                key.Add(6, this.intIdReclamo);

                Dictionary<int, string> values = new Dictionary<int, string>();
                values.Add(1, this.Area.ToString());
                values.Add(2, this.IdCliente.ToString());
                values.Add(3, this.Servicio.ToString());
                values.Add(4, this.TipoSoli.ToString());
                values.Add(5, this.Fecha);
                values.Add(6, this.intIdReclamo.ToString());
                values.Add(7, this.intIdTipoReclamo.ToString());
                values.Add(8, this.intIdSolucion.ToString());
                values.Add(9, this.dblCosto.ToString());

                if (persistance.SaveData(SolicitudType.RECLAMO, key, values))
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
            if (intIdTipoReclamo == 0)
            {
                sbError.AppendLine("El campo tipo reclamo es obligatorio");
            }
            if (intIdSolucion == 0)
            {
                sbError.AppendLine("El campo solicitud es obligatorio");
            }
            if (dblCosto == 0)
            {
                sbError.AppendLine("El campo costo es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
