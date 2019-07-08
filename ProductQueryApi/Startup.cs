using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventSubscriber.Events;
using EventSubscriber.Configuration;
using EventSubscriber.Queues.AMQP;
using ProductRepository.Repository;
using RabbitMQ.Client;
using EventSubscriber.Interfaces;
using ProductRepository.Interfaces;
using RabbitMQ.Client.Events;
using Database;
using ProductQueryModels;
using ProductQueryApi.Cache;

namespace ProductRepository
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddOptions();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IProductRepository, ProductDatabaseRepository>();
            services.AddTransient(typeof(EventingBasicConsumer), typeof(AMQPEventingConsumer));
            services.Configure<QueueOptions>(Configuration.GetSection("QueueOptions"));
            services.Configure<AMQPOptions>(Configuration.GetSection("amqp"));
            services.AddTransient(typeof(IConnectionFactory), typeof(AMQPConnectionFactory));
            services.AddSingleton(typeof(IEventSubscriber), typeof(AMQPEventSubscriber));
            services.AddSingleton(typeof(IEventProcessor), typeof(NewProductEventProcessor));
            services.AddTransient(typeof(IProductDatabase), typeof(ProductLiteDB));
            services.AddTransient(typeof(ICatagoryDatabase), typeof(CatagoryLiteDB));

            services.AddMemoryCache();
            services.AddSingleton<IProductCache, MemoryProductCache>();
        }

        // Singletons are lazy instantiation.. so if we don't ask for an instance during startup,
        // they'll never get used.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IEventProcessor eventProcessor)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc();
            eventProcessor.Start();
        }
    }
}
