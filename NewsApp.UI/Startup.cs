using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NewsApp.DAL;
using NewsApp.DAL.Entity;
using NewsApp.DAL.Repository.Abstraction;
using NewsApp.DAL.Repository.Implement;
using NewsApp.Domain.Interfaces;
using NewsApp.Domain.Services;
using NewsApp.UI.Helper;
using System.Text;

namespace NewsApp.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {




            services.AddCors();
            //додаємо контекст
            services.AddDbContext<EFContext>(option=>
                option.UseSqlServer(Configuration["ConnectionString"],
                x=>x.MigrationsAssembly("NewsApp.UI"))
                );

            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<EFContext>().
                AddDefaultTokenProviders();

            services.AddTransient<IJWTTokenService, JWTTokenService>();


            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = false;
            });

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("SecretPhrase")));

            var jwtSecret = Configuration["SecretPhrase"];
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signInKey,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero
                };
            });
            services.AddScoped<IGenericRepository<News>, EFRepository<News>>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IGenericRepository<Categori>, EFRepository<Categori>>();
            services.AddScoped<ICategoriService, CategoriService>();
            services.AddScoped<IGenericRepository<UserAdditional>, EFRepository<UserAdditional>>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IGenericRepository<Comments>, EFRepository<Comments>>();

            services.AddScoped<IGenericRepository<UserIsFavorite>, EFRepository<UserIsFavorite>>();

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));


            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            if(!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            //SeederDB.SeedData(app.ApplicationServices, env, Configuration);

        }
    }
}
