using Autofac;
using Autofac.Integration.Mvc;
using ET.Constracts.CarConstracts;
using ET.Constracts.PermissionContracts;
using ET.Constracts.RequestContracts;
using ET.Constracts.RoleConstracts;
using ET.Constracts.UserContracts;
using ET.Data.Context;
using ET.Data.Repositories;
using ET.Domain.CarAgg;
using ET.Domain.RequestAgg;
using ET.Domain.RoleAgg;
using ET.Domain.UserAgg;
using ET.Service.Services;
using System.Web.Mvc;

namespace ET.IoC
{
   public class ETBootstrapper
   {
      private ContainerBuilder builder = new ContainerBuilder();

      public ContainerBuilder Container() => builder;

      public void Resolve() 
      {
         var container = builder.Build();
         DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
      }

      public void Configure(string connectionString)
      {
         // Repositories : 
         builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
         builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerRequest();
         builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
         builder.RegisterType<RequestRepository>().As<IRequestRepository>().InstancePerRequest();

         // Services :
         builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
         builder.RegisterType<CarService>().As<ICarService>().InstancePerRequest();
         builder.RegisterType<RoleService>().As<IRoleService>().InstancePerRequest();
         builder.RegisterType<RequestService>().As<IRequestService>().InstancePerRequest();
         builder.RegisterType<PermissionExposer>().As<IPermissionExposer>().InstancePerLifetimeScope();

         builder.Register(c => new ETContext()).As<ETContext>().InstancePerRequest();
      }
   }
}