using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Command;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Handler;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Queries;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Data;
using System;
using System.Collections.Generic;
using Poulina.ProjectManagmentMS.Data.Repository;

namespace Poulina.ProjectManagmentMs.Infra
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<PoulinaDbContext>();
            #region Machine

            //Queries
            services.AddTransient<IGenericRepository<Machine>, GenericRepository<Machine>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Machine>, IEnumerable<Machine>>, GetListGenericHandler<Machine>>();
            services.AddTransient<IRequestHandler<GetByIdGenericQuery<Machine>, Machine>, GetByIdGenericHandler<Machine>>();


            //Commands
            services.AddTransient<IRequestHandler<PostGenericCommand<Machine>, string>, PostGenericHandler<Machine>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Machine>, string>, PutGenericHandler<Machine>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Machine>, string>, RemoveGenericHandler<Machine>>();


            #endregion
            #region Fournisseur

            //Queries
            services.AddTransient<IGenericRepository<Fournisseur>, GenericRepository<Fournisseur>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Fournisseur>, IEnumerable<Fournisseur>>, GetListGenericHandler<Fournisseur>>();
            services.AddTransient<IRequestHandler<GetByIdGenericQuery<Fournisseur>, Fournisseur>, GetByIdGenericHandler<Fournisseur>>();


            //Commands
            services.AddTransient<IRequestHandler<PostGenericCommand<Fournisseur>, string>, PostGenericHandler<Fournisseur>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Fournisseur>, string>, PutGenericHandler<Fournisseur>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Fournisseur>, string>, RemoveGenericHandler<Fournisseur>>();





            #endregion
            #region Filiaire

            //Queries
            services.AddTransient<IGenericRepository<Filiaire>, GenericRepository<Filiaire>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Filiaire>, IEnumerable<Filiaire>>, GetListGenericHandler<Filiaire>>();
            services.AddTransient<IRequestHandler<GetByIdGenericQuery<Filiaire>, Filiaire>, GetByIdGenericHandler<Filiaire>>();


            //Commands
            services.AddTransient<IRequestHandler<PostGenericCommand<Filiaire>, string>, PostGenericHandler<Filiaire>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Filiaire>, string>, PutGenericHandler<Filiaire>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Filiaire>, string>, RemoveGenericHandler<Filiaire>>();





            #endregion
            #region Service

            //Queries
            services.AddTransient<IGenericRepository<Service>, GenericRepository<Service>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Service>, IEnumerable<Service>>, GetListGenericHandler<Service>>();
            services.AddTransient<IRequestHandler<GetByIdGenericQuery<Service>, Service>, GetByIdGenericHandler<Service>>();


            //Commands
            services.AddTransient<IRequestHandler<PostGenericCommand<Service>, string>, PostGenericHandler<Service>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Service>, string>, PutGenericHandler<Service>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Service>, string>, RemoveGenericHandler<Service>>();


         
         


           



            #endregion




        }
    }
}
