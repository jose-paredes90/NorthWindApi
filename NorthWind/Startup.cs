using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NorthWind.Business;
using NorthWind.Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NorthWind.Interfaces.Business;
using Microsoft.OpenApi.Models;
using System.Text;

namespace NorthWind
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            //Server=CDA-AR-0679\\SQLEXPRESS; Database=Northwind; Integrated security = true;
            //services
            services.AddTransient<IProductsBiz, ProductsBiz>();
            services.AddTransient<ICategoryBiz, CategoryBiz>();
            services.AddTransient<ILoginBiz, LoginBiz>();
            services.AddTransient<ICustomerBiz, CustomerBiz>();
            services.AddTransient<ISupplierBiz, SupplierBiz>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Api Caduca REST", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
