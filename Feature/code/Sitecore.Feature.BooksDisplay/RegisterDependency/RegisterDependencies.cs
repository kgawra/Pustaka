using Sitecore.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Feature.BooksDisplay.Interfaces;
using Sitecore.Feature.BooksDisplay.Repositories;
using Sitecore.Feature.BooksDisplay.Controllers;

namespace Sitecore.Feature.BooksDisplay.RegisterDependency
{
    public class RegisterDependencies : IServicesConfigurator
    {
        /// <summary>
        /// Configure Path for Feature
        /// </summary>
        /// <param name="serviceCollection"></param>
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBooksRepository, BooksRepository>();
            serviceCollection.AddTransient<BooksController>();

        }
    }
}