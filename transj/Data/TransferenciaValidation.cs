using FluentValidation;

namespace transj.Data
{
    public class TransferenciaValidation :AbstractValidator<transferencia>
    {
        public TransferenciaValidation()
        {
            RuleFor(tra => tra.num_cta).NotNull().NotEmpty().MaximumLength(30).WithMessage("EL NUMERO DE BANCO  ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(tra => tra.cedula_cliente).NotEmpty().NotNull().MaximumLength(20).WithMessage("LA CEDULA CLIENTE ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(tra => tra.monto).NotNull().NotEmpty().WithMessage("EL MONTO  ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(tra => tra.estado).NotEmpty().NotNull().MaximumLength(20).WithMessage("EL ESTADO ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
        }
    }
}
