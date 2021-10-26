using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.enums
{
    #region Solicitudes Types
    public enum AreaType
    {
        Calidad = 1,
        Desarrollo = 2,
        Analisi = 3,
        Gerencia = 4,
        Ventas = 5
    }

    public enum ServicioType
    {
        Telefonia = 1,
        Internet = 2,
        Television = 3,
        Agua = 4,
        Luz = 5,
        Alcantarillado = 6
    }

    public enum SolicitudType
    {
        Peticion = 1,
        Queja = 2,
        Reclamo = 3,
        Sugerencia = 4,
        Felicitacion = 5
    }

    #endregion

    #region Quejas Types
    public enum RemuneracionType
    {
        Monetaria = 1,
        AumentoCapacidades = 2,
        OtrasDadivas = 3
    }
    #endregion

    #region Reclamos
    public enum ReclamoType
    {
        Facturacion = 1,
        Confuracion = 2,
        Instalacion = 3
    }

    public enum SolucionType
    {
        Correcion = 1,
        Aclaracion = 2,
        Remuneracion = 3
    }
    #endregion


}
