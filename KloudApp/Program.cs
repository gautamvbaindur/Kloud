using Autofac;
using Kloud.BusinessLogic.Business;
using Kloud.BusinessLogic.Service;
using KloudApp.ConfigManager;
using System.Linq;

namespace KloudApp
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            RegisterDependencies();
            var configManager = Container.Resolve<IConfigurationManager>();
            var ownerService = Container.Resolve<IOwnerService>();

            var brandsAndOwners = new Business(ownerService).GetBrandsGrouped();

            brandsAndOwners.ToList().ForEach(detail =>
            {
                System.Console.WriteLine($"{detail.BrandName}");
                detail.BrandOwners.ToList().ForEach(name =>
                {
                    System.Console.WriteLine($"\t{name}");
                });
            });
        }

        private static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConfigurationManager>().As<IConfigurationManager>();
            builder.RegisterType<OwnerService>().As<IOwnerService>();
            Container = builder.Build();
        }
    }
}
