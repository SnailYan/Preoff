using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Preoff.Entity;
using Preoff.Data;
using Autofac;
using System.Reflection;
using log4net.Repository;
using log4net.Config;
using log4net;

namespace Preoff
{
    /// <summary>
    /// 入口
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Logrepository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Logrepository, new FileInfo("log4net.config"));
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        public static ILoggerRepository Logrepository { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.AddEntityFrameworkSqlServer().AddDbContext<CoreTestContext>(opetions => opetions.UseSqlServer(Configuration.GetConnectionString("ConnDBString")));
            
            //services.AddScoped(typeof(IRepository<>), typeof(ImplRepository<>));



            var jwtSettings=new JwtSettings();
            Configuration.Bind("JwtSettings",jwtSettings);

            services.AddAuthentication(Options=>{
                Options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o=>{
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
                //o.SecurityTokenValidators.Clear();
                //o.SecurityTokenValidators.Add(new YanTokenValidator());
                //o.Events = new JwtBearerEvents()
                //{
                //    OnMessageReceived = context =>
                //    {
                //        var token = context.Request.Headers["token"];
                //        context.Token = token.FirstOrDefault();
                //        return Task.CompletedTask;
                //    }

                //};

            });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("SuperAdminOnly", policy => policy.RequireClaim("SuperAdminOnly"));
            //});

            //services.AddUnitOfWork<CoreTestContext>();
            //services.AddScoped(typeof(IDemoService), typeof(DemoService));

            services.AddMvc();

            // 注入的实现ISwaggerProvider使用默认设置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Preoff.xml");
                c.IncludeXmlComments(xmlPath);
            });
     }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api");
            });
            app.UseMvc();

            //var log = LogManager.GetLogger(Logrepository.Name, typeof(Startup));
            //log.Info("test");
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(ImplRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(typeof(TestDAL).GetTypeInfo().Assembly).AsImplementedInterfaces().AsSelf().PropertiesAutowired();//dal
            //builder.RegisterGeneric(typeof(ImplRepository<>))
            //    .InstancePerLifetimeScope()
            //    .OnActivating(handler =>
            //    {
            //        entityContext.SetDbContext(dbContext);

            //    }).As(typeof(IRepository<>));

            //var dataAccess = Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(dataAccess)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();



        }
    }
}
