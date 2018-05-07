using Autofac;
using Configuration.GraphQL;
using Services;

namespace Configuration
{
    public class DependecyRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DroidService>().As<IDroidService>().InstancePerLifetimeScope();
            builder.RegisterType<GraphQLRoot>().SingleInstance();
        }
    }
}