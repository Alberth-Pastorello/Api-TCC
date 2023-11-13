using Core.Messages.Notifications;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly DomainSuccesNotificationHandler _succesNotifications;
        private readonly IMediator _mediatorHandler;

        protected Guid ClienteId;

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
                                 INotificationHandler<DomainSuccesNotification> succesNotifications,
                                 IMediator mediatorHandler,
                                 IHttpContextAccessor httpContextAccessor)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _succesNotifications = (DomainSuccesNotificationHandler)succesNotifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
        protected IEnumerable<string> ObterMensagensDeSucesso()
        {

            return _succesNotifications.ObterNotificacoes().Select(c => c.Value).ToList();

        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.Publish(new DomainNotification(codigo, mensagem));
        }

        protected new IActionResult Response(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result,
                    messages = ObterMensagensDeSucesso()
                });
            }

            return BadRequest(new
            {
                success = false,
                messages = ObterMensagensErro(),
                data = result
            });
        }

        protected IActionResult NotFoundResponse(object? result = null)
        {
            return NotFound(new
            {
                success = false,
                errors = ObterMensagensErro(),
                data = result
            });
        }
    }
}
