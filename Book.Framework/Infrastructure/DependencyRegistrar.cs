using Autofac;
using Book.Core.Configuration;
using Book.Core.Data;
using Book.Core.Infrastructure;
using Book.Core.Infrastructure.DependencyManagement;
using Book.Core.Routing;
using Book.Domain.Data;
using Book.Framework.Mvc.Routing;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, GrandConfig config)
        {
            RegisterDataLayer(builder);

            RegisterCache(builder, config);

            RegisterCore(builder);

            RegisterContextService(builder);

            RegisterValidators(builder, typeFinder);

            RegisterFramework(builder);
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        private void RegisterCore(ContainerBuilder builder)
        {
           
        }

        private void RegisterDataLayer(ContainerBuilder builder)
        {
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            if (string.IsNullOrEmpty(dataProviderSettings.DataConnectionString))
            {
                builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
                builder.Register(x => new MongoDBDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();
                builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();
            }
            if (dataProviderSettings != null && dataProviderSettings.IsValid())
            {
                var connectionString = dataProviderSettings.DataConnectionString;
                var mongourl = new MongoUrl(connectionString);
                var databaseName = mongourl.DatabaseName;
                builder.Register(c => new MongoClient(mongourl).GetDatabase(databaseName)).InstancePerLifetimeScope();
            }
            builder.RegisterType<MongoDBContext>().As<IMongoDBContext>().InstancePerLifetimeScope();

            //MongoDbRepository
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        }

        private void RegisterCache(ContainerBuilder builder, GrandConfig config)
        {
            
        }

        private void RegisterContextService(ContainerBuilder builder)
        {
            
        }


        private void RegisterValidators(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            
        }

        private void RegisterFramework(ContainerBuilder builder)
        {
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }

    }
}
