using Blazor.Widgetised;
using Blazor.Widgetised.Logging;
using Blazor.Widgetised.Messaging;
using Blazor.Widgetised.Presenters;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWritable, WritableConsole>();
            services.AddSingleton<ILogger, TextLogger>();
            services.AddSingleton<IMessageBus, MessageBus>();
            services.AddSingleton<IWidgetContainerManagement, WidgetContainerManagement>();
            services.AddSingleton<IWidgetStore, WidgetStore>();
            services.AddSingleton<IWidgetStateStore, WidgetStateStore>();
            services.AddSingleton<IWidgetFactory, WidgetFactory>();
            services.AddSingleton<IWidgetManagementService, WidgetManagementService>();

            services.RegisterWidgets();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
            app.RegisterWidgetVariants();

            // Instanciate WidgetManagementService
            app.Services.GetRequiredService<IWidgetManagementService>();
        }
    }
}
