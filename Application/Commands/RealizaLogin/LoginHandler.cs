using MediatR;
using System.Security.Claims;
using Application.DTOs.Login;
using Core.Messages.Notifications;

namespace Application.Commands.RealizaLogin
{
    public class LoginHandler : IRequestHandler<LoginCommand, RespostaLoginDTO>
    {
        private CancellationToken _cancellationToken;
        private readonly IMediator _mediator;
        // private readonly ITokenService _tokenService;
        // private readonly IUsuarioRepository _usuarioRepository;
        // private readonly UserManager<IdentityUser> _userManager;
        // private readonly SignInManager<IdentityUser> _signInManager;

        public LoginHandler(
            IMediator mediator
        // ITokenService tokenService,
        // IUsuarioRepository usuarioRepository,
        // UserManager<IdentityUser> userManager,
        // SignInManager<IdentityUser> signInManager
        )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            // _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            // _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            // _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            // _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<RespostaLoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            if (!request.EhValido())
            {
                foreach (var item in request.ObterMensagensErro())
                {
                    await _mediator.Publish(new DomainNotification(key: "Login", value: item), cancellationToken);
                }

                return new RespostaLoginDTO();
            }
            // var usuario = await _userManager.FindByEmailAsync(request.Email);

            // if (usuario is null)
            // {
            //     await _mediator.Publish(new DomainNotification(key: "Login", value: "Usuário ou senha inválidos!"), _cancellationToken);
            //     return default;
            // }

            // return await RealizarLogin(command: request, usuario);
            return default;
        }

        // private async Task<RespostaLoginDTO> RealizarLogin(LoginCommand command, IdentityUser usuario)
        // {
        //     var loginResult = await _signInManager.PasswordSignInAsync(usuario, command.Senha, true, false);

        //     if (!loginResult.Succeeded)
        //     {
        //         await _mediator.Publish(new DomainNotification(key: "Login", value: "Usuário ou senha inválidos!"), _cancellationToken);
        //         return default;
        //     }

        //     var claims = (List<Claim>)await _userManager.GetClaimsAsync(usuario);

        //     claims.AddRange(new List<Claim>{
        //                         new Claim("id", IdentityUser.Id.ToString()),
        //                         new Claim("nome", IdentityUser.Nome)
        //                     });

        //     var token = _tokenService.GerarToken(claims);
        //     var refreshToken = _tokenService.GerarRefreshToken();

        //     IdentityUser.AtualizarTokens(token, refreshToken);
        //     _usuarioRepository.Atualizar(IdentityUser);
        //     var usuarioSalvo = await _usuarioRepository.UnitOfWork.Commit();
        //     if (!usuarioSalvo)
        //     {
        //         await _mediator.Publish(new DomainNotification("LoginHandler", "Não foi possível salvar os tokens do usuário."), _cancellationToken);
        //         return default;
        //     }

        //     return new RespostaLoginDTO
        //     {
        //         Token = token,
        //         RefreshToken = refreshToken

        //     };
        // }
    }
}