using FluentValidation;

namespace transj.Data
{
    public class BancoValidation : AbstractValidator<banco>


    {

        public BancoValidation()
        {
            RuleFor(ban => ban.cod_banco).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20).WithMessage("EL CODIGO DE BANCO ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(ban => ban.nombre_banco).NotNull().NotEmpty().MinimumLength(3).MaximumLength(30).WithMessage("EL NOMBRE DE BANCO ES UN CAMPO REQUERIDO FAVOR VERIFICAR"); ;
            RuleFor(ban => ban.direccion).NotEmpty().NotNull().MinimumLength(5).WithMessage("LA DIRRECION ES UN CAMPO REQUERIDO FAVOR VERICAR");
        }
    }
}
