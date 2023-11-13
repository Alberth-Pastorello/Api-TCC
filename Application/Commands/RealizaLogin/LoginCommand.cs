using Application.DTOs.Login;
using FluentValidation;
using Core.Messages;

namespace Application.Commands.RealizaLogin
{
    public class LoginCommand : Command<RespostaLoginDTO>
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public LoginCommand(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }
        public override bool EhValido()
        {
            ValidationResult = new LoginCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public List<string> ObterMensagensErro()
        {
            ValidationResult = new LoginCommandValidation().Validate(this);
            return ValidationResult.Errors.Select(c => c.ErrorMessage).ToList();

        }
    }
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public const string USUARIO_INVALIDO = "Usuario obrigatório!";
        public const string SENHA_INVALIDA = "Senha obrigatória!";

        public LoginCommandValidation()
        {
            RuleFor(c => c.Usuario)
                .NotNull()
                .NotEmpty()
                .WithMessage(USUARIO_INVALIDO);
            RuleFor(c => c.Senha)
                .NotNull()
                .NotEmpty()
                .WithMessage(SENHA_INVALIDA);
        }
    }
}