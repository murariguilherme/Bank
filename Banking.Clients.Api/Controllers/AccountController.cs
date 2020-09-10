using System;
using System.Threading.Tasks;
using Banking.Clients.Application.Commands;
using Banking.Clients.Application.Interfaces;
using Banking.Clients.Application.ViewModels;
using Banking.Core.Communication;
using Banking.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Clients.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class AccountController: MainController
    {
        private IMediatorHandler _mediatorHandle;
        private IUser _user;
        public AccountController(IMediatorHandler mediatorHandle,
                              INotificationHandler<DomainNotification> notifications,
                              IUser user): base(mediatorHandle, notifications, user)
        {
            _mediatorHandle = mediatorHandle;
            _user = user;
        }

        [HttpPost("update-client")]
        public async Task<ActionResult> UpdateClient([FromBody] ClientViewModel clientViewModel)
        {
            var command = new UpdateClientCommand(clientViewModel.Name, clientViewModel.Birthday,
                                                  clientViewModel.Passport, clientViewModel.StreetAddress,
                                                  clientViewModel.City, clientViewModel.State,
                                                  clientViewModel.PostalCode, _user);
            await _mediatorHandle.PublishCommand(command);

            return CustomResponse(clientViewModel);
        }
        
        [HttpPost("update-address")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressViewModel addressViewModel)
        {
            var command = new UpdateAddressClientCommand(addressViewModel.StreetAddress,
                                                          addressViewModel.City,
                                                          addressViewModel.State,
                                                          addressViewModel.PostalCode, _user);            
            await _mediatorHandle.PublishCommand(command);

            return CustomResponse(addressViewModel);
        }
    }
}
