using Autofac;
using Exercise.EntityFramework.Patterns.Repository;
using System.Data.Entity;

namespace Exercise.EntityFramework.Patterns.UnitOfWork
{
    public class UnitOfWorkModule : Module
    {
        private readonly string _dbConnection;

        public UnitOfWorkModule(string dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Context
            builder.RegisterType<DbContext>()
                .AsSelf()
                .WithParameter(new TypedParameter(typeof(string), _dbConnection))
                .InstancePerLifetimeScope();

            // Repositories
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>();

            // UnitOfWork
            builder.RegisterType<SimpleUnitOfWork>()
                .AsSelf()
                .InstancePerLifetimeScope()
                .OwnedByLifetimeScope();

            builder.RegisterType<LazyUnitOfWork>()
                .AsSelf()
                .InstancePerLifetimeScope()
                .OwnedByLifetimeScope();
        }
    }
}
