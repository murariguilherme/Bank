using Microsoft.AspNetCore.Mvc;
using Banking.Core.Communication;
using Banking.Core.Messages.Notifications;
using Banking.Clients.Application.Interfaces;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Banking.Core.Messages;
using MediatR;

namespace Banking.Clients.Api.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        private IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _notifications;
        private IUser _user;
        protected Guid UserId { get; set; }
        protected bool UserAuthenticated { get; set; }

        public MainController(IMediatorHandler mediatorHandle, INotificationHandler<DomainNotification> notifications, IUser user)
        {
            _mediatorHandler = mediatorHandle;
            _notifications = (DomainNotificationHandler)notifications;
            _user = user;

            if (_user.IsAuthenticated())
            {
                UserId = _user.GetUserId();
                UserAuthenticated = true;
            }
        }

        protected bool IsValid()
        {
            return !_notifications.HasNotifications();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidMotelState(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidMotelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError("key", errorMsg);
            }
        }

        protected void NotifyError(string key, string message)
        {
            _mediatorHandler.PublishNotification(new DomainNotification(key, message));
        }
    }
}
