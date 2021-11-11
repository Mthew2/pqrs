using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace PQRS.API.Models
{
    using Persistance;
    using helpers;

    public class Peticion : Solicitud
    {

        private int intIdPeticion;
        private int intIdSupervisor;

        public Peticion()
        { }

        public int Idpeticion
        {
            get { return intIdPeticion; }
            set { intIdPeticion = value; }
        }

        public int IdSupervisor
        {
            get { return intIdSupervisor; }
            set { intIdSupervisor = value; }
        }

        public override bool Consultar()
        {
            try
            {
                ExcelPersistance persistance = new ExcelPersistance();
                DataTable dt = persistance.GetData(SolicitudType.PETICION);

                if (dt.Rows.Count == 0)
                {
                    this.Error = "El Arachivo no contiene informnación";
                    return false;
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString() == this.intIdPeticion.ToString())
                    {
                        this.Area = Convert.ToInt32(dt.Rows[i]["Area"]);
                        this.IdCliente = Convert.ToInt32(dt.Rows[i]["IdCliente"]);
                        this.Servicio = Convert.ToInt32(dt.Rows[i]["Servicio"]);
                        this.TipoSoli = Convert.ToInt32(dt.Rows[i]["TipoSoli"]);
                        this.Fecha = Convert.ToString(dt.Rows[i]["Fecha"]);
                        this.intIdSupervisor = Convert.ToInt32(dt.Rows[i]["IdSupervisor"]);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Peticion> GetAll()
        {
            try
            {
                ExcelPersistance persistance = new ExcelPersistance();
                DataTable dt = persistance.GetData(SolicitudType.PETICION);

                if (dt.Rows.Count == 0)
                {
                    this.Error = "El Arachivo no contiene informnación";
                    return null;
                }

                List<Peticion> list = new List<Peticion>();
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString() == this.intIdPeticion.ToString())
                    {
                        Peticion item = new Peticion()
                        {
                            Area = Convert.ToInt32(dt.Rows[i]["Area"]),
                            IdCliente = Convert.ToInt32(dt.Rows[i]["IdCliente"]),
                            Servicio = Convert.ToInt32(dt.Rows[i]["Servicio"]),
                            TipoSoli = Convert.ToInt32(dt.Rows[i]["TipoSoli"]),
                            Fecha = Convert.ToString(dt.Rows[i]["Fecha"]),
                            intIdSupervisor = Convert.ToInt32(dt.Rows[i]["IdSupervisor"])
                        };
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                return null;
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
                this.intIdPeticion = IdGenerator.PeticionID;
                ExcelPersistance persistance = new ExcelPersistance();

                Dictionary<int, int> key = new Dictionary<int, int>();
                key.Add(6, this.intIdPeticion);

                Dictionary<int, string> values = new Dictionary<int, string>();
                values.Add(1, this.Area.ToString());
                values.Add(2, this.IdCliente.ToString());
                values.Add(3, this.Servicio.ToString());
                values.Add(4, this.TipoSoli.ToString());
                values.Add(5, this.Fecha);
                values.Add(6, this.intIdPeticion.ToString());
                values.Add(7, this.intIdSupervisor.ToString());

                if (persistance.SaveData(SolicitudType.PETICION, key, values))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
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
            if (intIdSupervisor == 0)
            {
                sbError.AppendLine("El campo supervisor es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
