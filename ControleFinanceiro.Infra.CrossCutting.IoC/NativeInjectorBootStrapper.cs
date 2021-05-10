using AutoMapper;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Repository;
using ControleFinanceiro.Data.Repository.ReadOnly;
using ControleFinanceiro.Data.UoW;
using ControleFinanceiro.Domain.Commands.Lancamentos;
using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Interfaces;
using ControleFinanceiro.Domain.Core.Notifications;
using ControleFinanceiro.Domain.Events.Lancamentos;
using ControleFinanceiro.Domain.Handlers;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Repository.ReadOnly;
using ControleFinanceiro.Infra.CrossCutting.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Mapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            //Commands
            services.AddScoped<IHandler<AdicionarLancamentoCommand>, LancamentoCommandHandler>();
            services.AddScoped<IHandler<AtualizarLancamentoCommand>, LancamentoCommandHandler>();
            services.AddScoped<IHandler<RemoverLancamentoCommand>, LancamentoCommandHandler>();


            //Events
            services.AddScoped<IHandler<LancamentoAdicionadoEvent>, LancamentoEventHandler>();
            services.AddScoped<IHandler<LancamentoAtualizadoEvent>, LancamentoEventHandler>();
            services.AddScoped<IHandler<LancamentoRemovidoEvent>, LancamentoEventHandler>();

            //Repository
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();


            //RepositoryReadOnly
            services.AddScoped<ILancamentoReadOnlyRepository, LancamentoReadOnlyRepository>();

            //Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ControleFinanceiroContext>();

            //Infra - Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Handler
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>(); 

        }
    }
}
