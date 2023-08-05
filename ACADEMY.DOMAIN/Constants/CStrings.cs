namespace ACADEMY.DOMAIN.Constants
{
    public static class CStrings
    {
        public const string ERROR_GENERICO = "Ha ocurrido una excepción, vuelva a intentar, en caso de que el error persista levantar un ticket de soporte.";

        public const string NOT_AUTHORIZED = "El usuario no se encuentra autorizado para realizar esta acción.";
        public const string SESION_FINISHED = "La sesión se cerró exitosamente";

        public const string NOT_FOUND = "El recurso solicitado no existe en el servidor.";

        public const string ERROR_CREDENTIALS = "Usuario y/o contraseña incorrecto.";
        public const string ERROR_CREDENTIALS_EDOC = "Credenciales de EDOC inválidas.";
        public const string MAX_INTENTOS = "¡Usuario bloqueado!, Ha excedido el máximo de intentos, ingrese a la opción: ¿Olvidaste tu contraseña? Para el desbloqueo del usuario.";
        public const string VENC_CONTRASEÑA = "La contraseña ha expirado, ingrese a la opción: ¿Olvidaste tu contraseña? Para cambiar la contraseña.";

        public const string CORREO_INCORRECTO = "El correo ingresado es incorrecto.";
        public const string CODIGO_INCORRECTO = "El código ingresado es incorrecto.";

        public const string VERIFICA_CLAVE = "La contraseña ingresada no coincide con la registrada, por favor intentelo nuevamente.";
        public const string VERIFICA_CORREO = "El correo ingresado ya existe, por favor intente con un correo diferente.";
        public const string VERIFICA_USUARIO = "El usuario ingresado ya existe, por favor intente con un usuario diferente.";

        public const string CODIGO_ENVIADO = "El código fue enviado al correo exitosamente.";
        public const string CODIGO_VALIDADO = "El código fue validado exitosamente.";
        public const string CLAVE_ACTUALIZADA = "La contraseña fue actualizada exitosamente.";

        public const string RESPONSE_INSERT = "Los datos se han registrado correctamente.";
        public const string RESPONSE_UPDATE = "Los datos se han actualizado correctamente.";
        public const string RESPONSE_ESTADO = "El estado del registro se ha actualizado con éxito.";

        public const string CLIENTES_SYNC = "Los clientes fueron sincronizados exitosamente.";
        public const string PRODUCTOS_SYNC = "Los productos fueron sincronizados exitosamente.";
        public const string FORMA_PAGO_SYNC = "Las formas de pago fueron sincronizadas exitosamente.";

        public const string FACTURA_ENVIADA = "La factura fue enviada exitosamente a SAP.";
        public const string FACTURAS_ENVIADA = "Las facturas pendientes se enviaron exitosamente a SAP.";

        public const string PRELIMINAR_GUARDADO = "El preliminar se guardó exitosamente.";
        public const string PRELIMINAR_ANULADO = "El preliminar fue anulado con éxito.";

        public const string FACTURA_SINCRONIZADA = "Los estados se sincronizaron correctamente.";
        public const string PEDIDO_SINCRONIZADO = "El pedido se encuentra sincronizado con SAP.";

        public const string DOCUMENTO_NO_AUTORIZADO = "El documento no se encuentra autorizado.";
    }
}