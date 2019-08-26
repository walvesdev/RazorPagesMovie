﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace RazorPagesMovie
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
            services.AddRazorPages();

            //services.AddDbContext<RazorPagesMovieContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("RazorPagesMovieContext")));

            services.AddDbContext<RazorPagesMovieContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("RazorPagesMovieContext")));
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

            //var defaultCulture = new CultureInfo("pt-BR");
            //var localizationOptions = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(defaultCulture),
            //    SupportedCultures = new List<CultureInfo> { defaultCulture },
            //    SupportedUICultures = new List<CultureInfo> { defaultCulture }
            //};
            //app.UseRequestLocalization(localizationOptions);

            //app.UseRequestLocalization("pt-BR");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
