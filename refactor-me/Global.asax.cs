using Autofac;
using Autofac.Integration.WebApi;
using Data;
using Data.ProductData;
using Data.ProductOptionData;
using refactor_me.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Get HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            // Set the dependency resolver to be Autofac.
                       
            builder.RegisterType<ProductService>().AsSelf();
            builder.RegisterType<ProductOptionService>().AsSelf();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductOptionRepository>().As<IProductOptionRepository>();

            var container = builder.Build();

            var prodRepo = container.Resolve<IProductRepository>();
            builder.Register(c => new ProductService(prodRepo))
                .AsSelf()
                .InstancePerApiControllerType(typeof(ProductsController));

            var prodOptionRepo = container.Resolve<IProductOptionRepository>();
            builder.Register(c => new ProductOptionService(prodOptionRepo))
                .AsSelf()
                .InstancePerApiControllerType(typeof(ProductOptionsController));

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
