using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
//import entity framework for dbcontext
using Microsoft.EntityFrameworkCore;
//import mysql to have your options connect to mysql
using Pomelo.EntityFrameworkCore.MySql;
//import your COntextClass that is responsible for retrieving data from database.
using NBAInfo.Data.Database;
//Import your services and thier corresponding interface to have it add to your configuration scope.
using NBAInfo.Services.Services.Player;
using NBAInfo.Services.Services.Player.Impl;
using NBAInfo.Services.Services.Team;
using NBAInfo.Services.Services.Team.Impl;
using NBAInfo.Services.Services.Coach;
using NBAInfo.Services.Services.Coach.Impl;
//import your repository and thier corresponding interface to have add to your configuration scope.
using NBAInfo.Data.Repositories.PlayerRepo;
using NBAInfo.Data.Repositories.PlayerRepo.Impl;
using NBAInfo.Data.Repositories.TeamRepo;
using NBAInfo.Data.Repositories.TeamRepo.Impl;
using NBAInfo.Data.Repositories.CoachRepo;
using NBAInfo.Data.Repositories.CoachRepo.Impl;

namespace NBAInfo.Web
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
            //NOw define a variable that will hold your connection string.
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //Now connect to your database using a connection string to your services variable
            services.AddDbContext<NBAInfoContext>(o => o.UseMySql("Server=127.0.0.1;Database=nba;User=root;Password=root;"));
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
                options.CacheProfiles.Add("1MinuteCache",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.Client,
                        Duration = 60
                    });
                options.CacheProfiles.Add("1HourCache",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.Client,
                        Duration = 3600
                    });
            });
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, NBAInfoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin()
                                    .AllowCredentials());
            app.UseCors();
            app.UseMvc();
        }
    }
}
