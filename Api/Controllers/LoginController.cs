using Core.Messages.Notifications;
using Application.Commands.RealizaLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly IMediator _mediatorHandler;

        public Login(IMediator mediatorHandler,
                              INotificationHandler<DomainNotification> notifications,
                              INotificationHandler<DomainSuccesNotification> succesNotifications,
                              IHttpContextAccessor httpContextAccessor) : base(notifications, succesNotifications, mediatorHandler, httpContextAccessor)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(LoginCommand command)
        {
            return Response(await _mediatorHandler.Send(command));
        }

        // [HttpPost("refreshToken")]
        // [AllowAnonymous]
        // public async Task<IActionResult> ObterRefreshToken(RefreshTokenCommand command)
        // {
        //     return Response(await _mediatorHandler.Send(command));
        // }
    }
}