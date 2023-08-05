//using FluentValidation.Results;
//using ACADEMY.APPLICATION.Validators;
//using ACADEMY.DOMAIN.DTOs;
//using ACADEMY.DOMAIN.Interfaces;

//namespace ACADEMY.APPLICATION.Extensions
//{
//    public static class ValidatorExtensions
//    {
//        public static Task<ValidationResult> ValidarCliente(this ClienteDTO clienteDTO)
//        {
//            ClienteValidator validator = new();
//            return validator.ValidateAsync(clienteDTO);
//        }

//        public static ValidationResult ValidarClienteEvento(this ClienteEventoDTO clienteEventoDTO)
//        {
//            ClienteEventoValidator validator = new();
//            return validator.Validate(clienteEventoDTO);
//        }

//        public static ValidationResult ValidarClienteEventoMotivo(this ClienteEventoMotivoDTO clienteEventoMotivoDTO)
//        {
//            ClienteEventoMotivoValidator validator = new();
//            return validator.Validate(clienteEventoMotivoDTO);
//        }

//        public static ValidationResult ValidarErp(this ErpDTO erpDTO)
//        {
//            ErpValidator validator = new();
//            return validator.Validate(erpDTO);
//        }

//        public static ValidationResult ValidarGrupo(this GrupoDTO grupoDTO)
//        {
//            GrupoValidator validator = new();
//            return validator.Validate(grupoDTO);
//        }

//        public static Task<ValidationResult> ValidarPartner(this PartnerDTO partnerDTO)
//        {
//            PartnerValidator validator = new();
//            return validator.ValidateAsync(partnerDTO);
//        }

//        public static Task<ValidationResult> ValidarPedido(this PedidoDetalleDTO pedidoDTO, IUnitOfWork unitOfWork)
//        {
//            PedidoValidator validator = new(unitOfWork);
//            return validator.ValidateAsync(pedidoDTO);
//        }

//        public static Task<ValidationResult> ValidarPedidoAval(this PedidoAvalDTO pedidoAvalDTO)
//        {
//            PedidoAvalValidator validator = new();
//            return validator.ValidateAsync(pedidoAvalDTO);
//        }

//        public static ValidationResult ValidarRol(this PerfilDTO perfilDTO)
//        {
//            RolValidator validator = new();
//            return validator.Validate(perfilDTO);
//        }

//        public static Task<ValidationResult> ValidarUsuarioAsync(this UsuarioDTO usuarioDTO, IUnitOfWork unitOfWork)
//        {
//            UsuarioValidator validator = new(unitOfWork);
//            return validator.ValidateAsync(usuarioDTO);
//        }
//    }
//}