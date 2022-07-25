using FluentValidation;

namespace transj.Data
{
    public class CuentaValidation : AbstractValidator<cuenta>
    {

        public CuentaValidation()
        {
            RuleFor(cuenta => cuenta.num_cta).NotNull().NotEmpty().MaximumLength(15).MinimumLength(4).WithMessage("EL NUMERO DE CUENTA ES UN CAMPO REQUERIDO FAVOR VERIFICAR ");
            RuleFor(cuenta => cuenta.moneda).NotEmpty().NotNull().MaximumLength(3).MinimumLength(3).WithMessage("LA MONEDA ES UN CAMPO REQUERIDO FAVOR VERIFICAR ");
            RuleFor(cuenta => cuenta.cedula_cliente).NotEmpty().WithMessage("LA CEDULA  ES UN CAMPO REQUERIDO FAVOR VERIFICAR ");
            RuleFor(cuenta => cuenta.saldo).NotNull().NotEmpty().WithMessage("EL SALDO ES UN CAMPO REQUERIDO FAVOR VERIFICAR ");
            RuleFor(cuenta => cuenta.cod_banco).NotEmpty().NotNull().WithMessage("EL CODGIO DE BANCO  ES UN CAMPO REQUERIDO FAVOR VERIFICAR ");
        }
    }
}
