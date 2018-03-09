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
using Autofac;
using System.Reflection;
using log4net.Repository;
using log4net.Config;
using log4net;
using Preoff.Repository;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;

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
            //services.AddEntityFrameworkSqlServer().AddDbContext<CoreTestContext>(opetions => opetions.UseSqlServer(Configuration.GetConnectionString("ConnDBString")));
            services.AddEntityFrameworkSqlServer().AddDbContext<PreoffContext>(opetions => opetions.UseSqlServer(Configuration.GetConnectionString("ConnDBString"),b=>b.UseRowNumberForPaging()));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                 builder => builder.WithOrigins("http://localhost").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            #endregion
            // 注入的实现ISwaggerProvider使用默认设置
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api接口"
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
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api接口");
            });
            app.UseMvc();
            app.UseCors("AllowSpecificOrigin");

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(@"E:\", @"corewebapi")),
                RequestPath = new PathString("/Upload")
            });
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

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
            //var assembly = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly)
            //    .InNamespace("Preoff.Entity");
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Table"));

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<AircRepository>().As<IAircRepository>();
            builder.RegisterType<AirLoadRepository>().As<IAirLoadRepository>();
            builder.RegisterType<CameraRepository>().As<ICameraRepository>();
            builder.RegisterType<CameraTypeRepository>().As<ICameraTypeRepository>();
            builder.RegisterType<EventRepository>().As<IEventRepository>();
            builder.RegisterType<ExecTaskRepository>().As<IExecTaskRepository>();
            builder.RegisterType<DivisionRepository>().As<IDivisionRepository>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>();
            builder.RegisterType<UnitRepository>().As<IUnitRepository>();
            builder.RegisterType<FireStationDataRepository>().As<IFireStationDataRepository>();
        }
    }
}
