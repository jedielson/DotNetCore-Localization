using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using TesteInternalization.IoC.Common;
using TesteInternalization.IoC.Localization;

namespace TesteInternalization.IoC
{
    public class CustomIoCContainer : IocContainer
    {
        private readonly IServiceCollection _services;

        public CustomIoCContainer(IServiceCollection services, IConfiguration configuration) : base(services, configuration)
        {
            _services = services;
        }

        public override void RegisterModules()
        {
            _services.AddOptions();
            ConfigureLocalization(_services);
        }

        private void ConfigureLocalization(IServiceCollection services)
        {
            services.Configure<ClassLibraryLocalizationOptions>(opt =>
            {
                opt.ResourcePaths = new Dictionary<string, string>
                {
                    {"TesteInternationalization.Domain", "Resources"},
                    {"TesteInternationalization", "Resources"}
                };
            });

            services.TryAddSingleton(typeof(IStringLocalizerFactory), typeof(ClassLibraryStringLocalizerFactory));
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es"),
                };

                opt.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opt.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opt.SupportedUICultures = supportedCultures;
            });
        }
    }
}
