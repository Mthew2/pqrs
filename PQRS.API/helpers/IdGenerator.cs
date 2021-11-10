namespace PQRS.API.helpers
{
    public static class IdGenerator
    {
        private static int quejaID;
        public static int QuejaID
        {
            get { return quejaID += 1; }
        }

        private static int peticionID;
        public static int PeticionID
        {
            get { return peticionID += 1; }
        }

        private static int felicitacionID;
        public static int FelicitacionID
        {
            get { return felicitacionID += 1; }
        }

        private static int reclamoID;
        public static int ReclamoID
        {
            get { return reclamoID += 1; }
        }

        private static int solicitudID;
        public static int SolicitudID
        {
            get { return solicitudID += 1; }
        }

        private static int sugerenciaID;
        public static int SugerenciaID
        {
            get { return sugerenciaID += 1; }
        }
    }

    public class SolicitudType
    {
        public const string SOLICITUD = "Solicitud";
        public const string PETICION = "Peticion";
        public const string QUEJA = "Queja";
        public const string RECLAMO = "Reclamo";
        public const string SUGERENCIA = "Sugerencia";
        public const string FELICITACION = "Feliticiones";
    }
}


