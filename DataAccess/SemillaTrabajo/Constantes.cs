

namespace DataAccess.SemillaTrabajo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    public class Constantes
    {
        #region Mensajes de Error
        public const string ErrSAPConnection = "No se pudo conectar a SAP";
        public const string ErrSAPGetConfiguration = "Error al obtener parámetros de configuración";
        public const string FunctionSucessMsg = "La función se ejecutó satisfactoriamente";

        #endregion
        public const string ORIGEN_MACISA_ATC = "VMT";
        public const string ORIGEN_MACISA_CDC = "CONDORCO";
        public const string ORIGEN_LAVIGA_ATC = "0005";
        public const string ORIGEN_LAVIGA_CDC = "0013";
        public const string LAVIGA_ORIGEN_U_ATC = "U001";
        public const string LAVIGA_ORIGEN_U_CDC = "U002";

        public const string LA_VIGA_CRED_NO_EFECTUADA = "";
        public const string LA_VIGA_CRED_VERIF_OK = "A";
        public const string LA_VIGA_CRED_VERIF_NO_OK = "B";
        public const string LA_VIGA_CRED_VERIF_NO_OK_LIBPARC = "C";
        public const string LA_VIGA_CRED_LIBERADO_GESTCRED = "D";
        public const string LA_VIGA_CRED_VERIF_RECHAZADO = "R";
        public const string LA_VIGA_CRED_ANULADO = "X";

        public const string ABERIO_LINNEG_CEMENTO = "01";
        public const string ABERIO_CAMION_DISTRIBUIDOR = "01";
        public const string ABERIO_CAMION_TERCERO = "02";
        public const string ABERIO_ORIGEN_ATC = "01";
        public const string ABERIO_ORIGEN_CDC = "02";
        public const string ABERIO_PREF_PROVEEDOR = "PL";

        public const string PROGRE_CAMION_PROPIO = "01";
        public const string PROGRE_CAMION_TERCERO = "02";
        public const string PROGRE_CAMION_DISTRIB = "03";

        public const string MACISA_ORDEN_GENERADA = "Orden_Generada";

        public const string MACISA_ORDEN_AUN_NO_GENERADA = "No_genera_aun";
        public const string MACISA_ORDEN_OFERTA_CANCELADA = "Oferta_Cancelada";
        public const string MACISA_ORDEN_PEDIDO_HABILITADO = "Habilitado";
        public const string MACISA_ORDEN_PEDIDO_CANCELADA = "Cancelado";
        public const string MACISA_SE_EXTENDIO_TIEMPO = "";

        public const string COND_EXPED_DISTRIBUIDOR = "03";

        public const string ABERIO_CRED_CERRADO = "Cerrado";
        public const string ABERIO_CRED_ABIERTO = "Abierto";
        public const string ABERIO_CRED_ANULADO = "Anulado";

        public const string ABERIO_OFERTA = "oQuotations";
        public const string ABERIO_PEDIDO = "oOrders";


        #region TransactionMessages
        public const int SUCCESS_CODE = 0;
        public const int ERROR_CODE = -1;

        public const string REGISTER_SUCCESS_MESSAGE = "Se registró correctamente";
        public const string UPDATE_SUCCESS_MESSAGE = "Se actualizó correctamente";
        public const string SAVE_SUCCESS_MESSAGE = "Se grabó correctamente";
        public const string DELETE_SUCCESS_MESSAGE = "Se eliminó correctamente";
        public const string DATA_SUCCESS_MESSAGE = "Se consultó correctamente";
        public const string NOT_FOUND_MESSAGE = "Registro no encontrado";

        public const string TRANSACTION_ERROR = "Error al realizar la transacción";
        #endregion


        #region LineaCreditoConsolidado
        public const string SUCCESS_QUERING_EECC = "Exito al consultar EECC {0}";
        public const string ERROR_QUERING_EECC = "Error al consultar EECC {0}";
        public const string SUCESSS_WITH_ERROR_QUERING_EECC = "Algunas consultas de EECC {0} fallaron. Para más detalles revise el log.";

        public const string SUCCESS_QUERING_LINECREDIT_AND_ACCOUNTSTATES = "Éxito al consultar la linea de crédito y el estados de cuenta {0}";
        public const string ERROR_QUERING_LINECREDIT_AND_ACCOUNTSTATES = "Error al consultar la linea de crédito y el estados de cuenta {0}";
        public const string ERROR_QUERING_LINECREDIT_OR_ACCOUNTSTATES = "Error al consultar la linea de crédito o el estados de cuenta {0}";

        public const string EXCEPCION_INTENTO_CONSULTA_EECC = "Excepción de intento consultando EECC {0}: {1}";
        public const string CANT_REINTENTOS_CONSULTA_EECC = "Reintento de consultar EECC {0}: {1}";

        public const string DEALER_MACISA = "Macisa";

        public const string DETAIL_METHOD_GET_ACCOUNT_STATES = "consultando EECC {0}";
        #endregion
    }
}
