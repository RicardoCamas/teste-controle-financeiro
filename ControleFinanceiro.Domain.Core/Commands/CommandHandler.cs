using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Interfaces;
using ControleFinanceiro.Domain.Core.Notifications;
using FluentValidation.Results;
using System;

namespace ControleFinanceiro.Domain.Core.Commands
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IMediatorHandler _mediator;

        public CommandHandler(
            IUnitOfWork uow, 
            IMediatorHandler mediator,
            IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = notifications;
            _mediator = mediator;
        }
        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.PublicarEvento(new DomainNotification(error.PropertyName,error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _mediator.PublicarEvento(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }

        protected abstract (object entity, bool exist) EntidadeExistente(Guid id, string messageType);
        protected abstract bool EntidadeValida(object entity);
    }
}
