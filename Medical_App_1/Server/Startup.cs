
using Medical_App_1.Server.Factory;
using Medical_App_1.Server.Hubs;
using Medical_App_1.Server.ServerModels;
using Medical_App_1.Server.Services;
using Medical_App_1.Server.Services.Medical;
using Medical_App_1.Server.Services.Medical.Interfaces;
using Medical_App_1.Server.Services.Medical.SqlServerClass;
using Medical_App_1.Server.Services.UserManage;
using Medical_App_1.Server.Services.UserManage.Interfaces;
using Medical_App_1.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace Medical_App_1.Server
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Signalr
            services.AddSignalR();
            
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            //Add cros 
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                builder.WithOrigins(Configuration["KeyList:Clint1"], Configuration["KeyList:Clint2"])
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });
            //services.AddCors(options =>
            //{

            //    options.AddPolicy(MyAllowSpecificOrigins,
            //    builder =>
            //    {
            //        builder.AllowAnyOrigin()
            //   .AllowAnyMethod()
            //   .AllowAnyHeader();
                    
            //    });

            //});
           
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthentication(options =>
            {
                //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(jwtBearerOptions =>
                 {
                     jwtBearerOptions.RequireHttpsMetadata = true;
                     jwtBearerOptions.SaveToken = true;
                     jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWTSettings:SecretKey"])),
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ClockSkew = TimeSpan.Zero
                     };
                 });
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IPurchaseService, PuurchaseServiceSQLServer>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<ISalesService, SalesService>();
            IConnectionFactoryAuthDB connectionFactoryAuthDB = new ConnectionFactory(Configuration.GetConnectionString("AuthDBConnectionString"));            
           
            services.AddSingleton(connectionFactoryAuthDB);
            IConnectionFactoryMedicalDB connectionFactoryMedicalDB = new ConnectionFactory(Configuration.GetConnectionString("MedicalDBConnectionString"));

            services.AddSingleton(connectionFactoryMedicalDB);
            services.Configure<Keylist>(Configuration.GetSection("KeyList"));
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //signalr
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Add cros 
            // app.UseCors("_myAllowSpecificOrigins");
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                //signalr
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
