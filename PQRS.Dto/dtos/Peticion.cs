using System;
using System.Text;

namespace PQRS.Dto.dtos
{
    using Persistance;
    using helpers;
    using System.Data;

    public class Peticion: Solicitud
    {

        private int intIdPeticion;
        private int intIdSupervisor;

        public Peticion()
        {}

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
                DataTable dt = persistance.GetData("", "");

                if (dt.Rows.Count == 0) {
                    this.Error = "El Arachivo no contiene informnación";
                    return false;
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IdPeticion"].ToString() == this.intIdPeticion.ToString()) {
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

                throw;
            }
            
        }

        public override bool Registrar()
        {
            this.intIdPeticion = IdGenerator.PeticionID;
            this.Validar();
            ExcelPersistance persistance = new ExcelPersistance();

            //recive fila a ,insertar si la aemncuentra la actuliza, si no lña encuentra la agrega
            //persistance.saveData();
            return true;
        }

        public override bool Validar() {
            base.Validar();
            StringBuilder sbError = new StringBuilder("");
            if (intIdSupervisor == 0)
            {
                sbError.AppendLine("El campo supervisor es obligatorio");
            }
            this.Error += sbError.ToString();
            return String.IsNullOrEmpty(this.Error);
        }
    }
}
