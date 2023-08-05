namespace ACADEMY.DOMAIN.Constants
{
    public static class CEnums
    {
        public enum SfedocStatus
        {
            INSERTED,
            UPDATED,
            DELETED
        }

        public enum ComboBox
        {
            ClientesEventosMotivos,
            Erp,
            FormaPago,
            Grupo,
            Moneda,
            Perfil,
            TipoPedido,
            Usuario
        }

        public enum TipoApi
        {
            Edoc,
            Soporte
        }

        public enum BusinessPartnersTipoSearch
        {
            Cedula = 1,
            RazonSocial = 2
        }

        public enum PedidoTipoSearch
        {
            NumPedido = 1,
            Titulo = 2
        }

        public enum ProductoTipoSearch
        {
            Codigo = 1,
            Descripcion = 2
        }

        public enum UsuarioTipoSearch
        {
            Administrador = 1,
            Facturacion = 2,
            OfficeManager = 3,
            ProjectManager = 4,
            Comercial = 5
        }

        public enum TipoPedidoItem
        {
            Implementacion,
            Paquete,
            Soporte,
            Arrendamiento
        }

        public enum EstadoPedidoPendiente
        {
            FacturarInmediatamente = 1,
            OtrosPorFacturar = 2,
            Facturados = 3
        }

        public enum EstadoPedidoAval
        {
            PendienteSinExcepcion,
            PendienteConExcepcion,
            Avalados,
            Todos
        }

        public enum EstadoItemRecurrente
        {
            SinFecha,
            ConFecha,
            Todos
        }

        public enum GenerarRecurrencia
        {
            Limpiar,
            GeneraMensualidad,
            GeneraAnualidad,
            GeneraAnualidadAdicional,
            CargarMensualidad,
            CargarAnualidad,
            CargarAdicional,
            AsignarConteosMensual,
            AsignarConteosAdicional
        }

        public enum FacturasPendientes
        {
            NoEnviadas,
            PendientesSync
        }
    }
}