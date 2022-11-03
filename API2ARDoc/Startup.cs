using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace API2ARDoc
{
    public class Startup
    {
        string tC_AppName;
        string tC_AppVer;
        string tC_RunTimeVer;
        public static string tC_VirtualPath;
        public Startup(IConfiguration configuration)
        {
            string tPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string tFileName = Path.Combine(tPath, "test.log").Replace("\\","/");
            File.WriteAllText(tFileName, "This is test.");
            Configuration = configuration;
            //*Ton 64-05-19 Populate AppSettings
            Configuration.GetSection("AppSettings").Bind(cAppSetting.Default);

            foreach(PropertyInfo info in cAppSetting.Default.GetType().GetProperties())
            {
                string tEnvName = $"ENV_{info.Name}";
                string tEnvVal = Environment.GetEnvironmentVariable(tEnvName);
                if (!string.IsNullOrEmpty(tEnvVal))
                {
                    info.SetValue(cAppSetting.Default, tEnvVal);
                }
            }

            tC_VirtualPath = Environment.GetEnvironmentVariable("ENV_VirtualPath");
            //var netCoreVer = System.Environment.Version; // 3.0.0
            tC_AppName = Assembly.GetExecutingAssembly().GetName().Name;
            tC_AppVer = Assembly.GetEntryAssembly().GetName().Version.ToString();
            tC_RunTimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; // .NET Core 3.0.0-preview4.19113.15
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            const string tReqHeaders = "X-Api-Key";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{tC_AppName} V{tC_AppVer}", Version = $"{tC_RunTimeVer}" });
                c.AddSecurityDefinition(tReqHeaders, new OpenApiSecurityScheme
                {
                    Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                    In = ParameterLocation.Header,
                    Name = tReqHeaders,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = tReqHeaders,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = tReqHeaders
                            },
                         },
                         new string[] {}
                     }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseFileServer(new FileServerOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "HomePage")),
            //    RequestPath = "/home",
            //    EnableDefaultFiles = true
            //});

            //string contentPath = Path.Combine(env.ContentRootPath, "HomePage");
            ////string contentPath = env.ContentRootPath;
            //Console.WriteLine($"contentPath = {contentPath}");
            //if (Directory.Exists(contentPath))
            //{
            //    Console.WriteLine("Path Found.");
            //}
            //else
            //{
            //    Console.WriteLine("Path NotFound!");
            //}
            //app.UseFileServer(new FileServerOptions
            //{
            //    FileProvider = new PhysicalFileProvider(contentPath),
            //    RequestPath = "",
            //    EnableDefaultFiles = true
            //});

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{tC_VirtualPath}/swagger/v1/swagger.json", $"{tC_AppName} V{tC_AppVer}");
            });

        }
    }
}
