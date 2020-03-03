using CasaDoCodigo.Areas.Catalogo.Data;
using CasaDoCodigo.Areas.Catalogo.Data.Repositories;
using CasaDoCodigo.Data;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace CasaDoCodigo
{
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            ConfigurarContexto<ApplicationDbContext>(services, "Default");
            ConfigurarContexto<CatalogoDbContext>(services, "Catalogo");

            ConfigurarDI(services);

            services.AddAuthentication();
        }

        /// <summary>
        /// Configura os serviços para injeção de dependência
        /// </summary>
        private static void ConfigurarDI(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpHelper, HttpHelper>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
        }

        /// <summary>
        /// Configura o contexto do Entity Framework Core com uma string de conexão SQL Server
        /// </summary>
        private void ConfigurarContexto<T>(IServiceCollection services, string nomeConexao) where T: DbContext
        {
            string connectionString = Configuration.GetConnectionString(nomeConexao);

            services.AddDbContext<T>(options =>
                options.UseSqlServer(connectionString)
            );
        }

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

            MigrarBanco<ApplicationDbContext>(app);
            MigrarBanco<CatalogoDbContext>(app);

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "AreaCatalogo",
                    areaName: "Catalogo",
                    template: "Catalogo/{controller=Home}/{action=Index}/{pesquisa?}"
                );

                routes.MapAreaRoute(
                    name: "AreaCarrinho",
                    areaName: "Carrinho",
                    template: "Carrinho/{controller=Home}/{action=Index}/{codigo?}");

                routes.MapAreaRoute(
                    name: "AreaCadastro",
                    areaName: "Cadastro",
                    template: "Cadastro/{controller=Home}/{action=Index}");

                routes.MapAreaRoute(
                    name: "AreaPedido",
                    areaName: "Pedido",
                    template: "Pedido/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{codigo?}");
            });
        }

        private static void MigrarBanco<T>(IApplicationBuilder app) where T: DbContext
        {
            using (var seviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var contexto = seviceScope.ServiceProvider.GetService<T>())
                {
                    contexto.Database.Migrate();
                }
            }
        }
    }
}
