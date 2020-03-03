using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace CasaDoCodigo
{
    //DB 1): Startup
    #region Startup
    //Em Startup configuramos o Entity Framework
    //para usar o banco de dados 
    #endregion
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            string connectionString = Configuration.GetConnectionString("Default");

            //DB 2): Configuração EF+Sql Server
            #region Configuração EF+Sql Server
            //O banco de dados SQL Server
            //armazena dados do e-commerce
            //(produtos, pedidos, cadastro, etc.)
            //vide SQL Server Object Explorer 
            #endregion
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );

            //DB 3): Identity + SQLite
            #region SQLite
            //1.Relacional
            //2.Usa linguagem SQL 
            //3.pequeno
            //4.rápido
            //5.independente
            //6.confiável
            //7.cheio de recursos.
            //8.mais usado no mundo 
            //https://www.sqlite.org/index.html
            #endregion

            //DB 4): EF + SQLite?
            #region EF com outros bancos
            //O Entity Framework pode trabalhar com
            //diversos bancos de dados
            //https://docs.microsoft.com/pt-br/ef/core/providers/index
            #endregion

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpHelper, HttpHelper>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();

            //TAREFA: Permitir login externo 
            //com a conta da Microsoft
            //https://apps.dev.microsoft.com/

            //TAREFA: Permitir login externo 
            //com a conta do Google
            //https://developers.google.com/identity/sign-in/web/sign-in


            //HABILITE ESTAS LINHAS ABAIXO APENAS
            //APÓS CONFIGURAR SUA APLICAÇÃO NA MICROSOFT E NO GOOGLE.
            
            //services.AddAuthentication()
            //    .AddMicrosoftAccount(options =>
            //    {
            //        options.ClientId = Configuration["ExternalLogin:Microsoft:ClientId"];
            //        options.ClientSecret = Configuration["ExternalLogin:Microsoft:ClientSecret"];
            //    })
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = Configuration["ExternalLogin:Google:ClientId"];
            //        options.ClientSecret = Configuration["ExternalLogin:Google:ClientSecret"];
            //    });
        }


        // Este método é chamado pelo runtime.
        // Use este método para configurar o pipeline de requisições HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            _loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            //INTEGRACAO 1) adicionar componente Identity
            //ASP.NET Core utiliza o padrão "Cadeia de Responsabilidade"
            //https://pt.wikipedia.org/wiki/Chain_of_Responsibility
            /// <image url="pipeline4.png" scale="0.75"/>
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=BuscaProdutos}/{codigo?}");
            });

            var dataService = serviceProvider.GetRequiredService<IDataService>();
            dataService.InicializaDBAsync(serviceProvider).Wait();
        }
    }
}
