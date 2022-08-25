using Core.Common;
using Core.Repository;
using Core.Service;
using Infra.Common;
using Infra.Repository;
using Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaFinalProject.Api
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
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers();
            services.AddScoped<IDBContext, DBContext>();

            //----------------------for service
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IFollowersService, FollowersService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IInteractionService, InteractionService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IMediaPostService, MediaPostService>();
            services.AddScoped<ImessageService, MessageService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITestemonialService, TestemonialService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IService_FService, Service_FService>();
            services.AddScoped<IServiceUserService, ServiceUserService>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IVisaService, VisaService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //---------------------for repstory
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<ICommentReposetory, CommentReposetory>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IFollowersRepository, FollowersRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IInteractionRepository, InteractionRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IMediaPostRepository, MediaPostRepository>();
            services.AddScoped<ImessageRepository, MessageRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITestemonialRepository, TestemonialRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IService_FRepository, Service_FRepository>();
            services.AddScoped<IServiceUserRepository, ServiceUserRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<IVisaRepository, VisaRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer = false,
                    ValidateAudience = false,

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
             
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("policy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
