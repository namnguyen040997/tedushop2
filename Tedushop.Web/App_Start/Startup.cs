using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using Tedushop.Data;
using Tedushop.Data.Infrastructure;
using Tedushop.Data.Repositories;
using Tedushop.Service;

[assembly: OwinStartup(typeof(Tedushop.Web.App_Start.Startup))]

namespace Tedushop.Web.App_Start
{
    //Autofac DI Container
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register các controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            //Register WebApi Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 

            //Mỗi khi class nào gọi đến UnitOfWork,DbFactory thì nó sẽ instance ra 1 đối tượng(ko cần new cũng dùng đc)
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            //Khi gọi đến TedushopDbContext sẽ instance ra đối tượng TedushopDbContext (ko cần new cũng dùng đc)
            builder.RegisterType<TedushopDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();


            // Khởi tạo đối tượng repository tự động khi có request
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Khởi tạo đối tượng Service tự động khi có request
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();


            //Sau khi register xong , nó sẽ gán tất cả các register vào 1 cái thùng chứa (container) của autofac
            Autofac.IContainer container = builder.Build();
            //Thay đổi cơ chế Resolver mặc định thành cơ chế Resolver của Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Set cho API: GlobalConfiguration => Cả api, controller đều có thể dùng chung
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
