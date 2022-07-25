using FluentValidation;

namespace transj.Data
{
    public class ClienteValidation :AbstractValidator<cliente>
    {

        public ClienteValidation()
        {

            RuleFor(clien => clien.cedula_cliente).NotEmpty().NotNull().MinimumLength(6).WithMessage("CEDULA CLIENTE ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(clien => clien.tipo_doc).NotEmpty().NotNull().MinimumLength(3).MaximumLength(15).WithMessage("EL TIPO DE DOCUMENTO ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
            RuleFor(clien => clien.nombre_apellido).NotEmpty().NotNull().MinimumLength(10).MaximumLength(50).WithMessage("EL NOMBRE Y APELLIDO ES UN CAMPO REQUERIDO FAVOR VERIFICAR");
        }

    }
}
