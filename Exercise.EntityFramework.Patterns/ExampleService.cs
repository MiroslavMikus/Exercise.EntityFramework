using Autofac;
using Exercise.EntityFramework.Patterns.Model;
using Exercise.EntityFramework.Patterns.UnitOfWork;
using System.Collections.Generic;

namespace Exercise.EntityFramework.Patterns
{
    public class ExampleService
    {
        private IContainer _container;

        public ExampleService(string connectionString)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new UnitOfWorkModule(connectionString));

            _container = builder.Build();
        }

        public IEnumerable<User> RequestAllUsers()
        {
            using (var scope = _container.BeginLifetimeScope())
            using (var unitOfWork = scope.Resolve<LazyUnitOfWork>())
            {
                return unitOfWork.Users.All();
            }
        }
    }
}
