using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.ICommands.ICommandsArticleType;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.ICommands.ICommandsWaiter;
using RACommands.ArticleCommands;
using RACommands.ArticleTypeCommands;
using RACommands.OrderCommands;
using RACommands.TableCommands;
using RACommands.WaiterCommands;

namespace RestaurantMVC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<RestaurantContext>();
            services.AddTransient<IGetArticles, GetArticles>();
            services.AddTransient<IGetArticle, GetArticle>();
            services.AddTransient<IGetArticleTypes, GetArticleTypes>();
            services.AddTransient<IAddArticle, AddArticle>();
            services.AddTransient<IUpdateArticle, UpdateArticle>();
            services.AddTransient<IDeleteArticle, DeleteArticle>();
            services.AddTransient<IGetOrders, GetOrders>();
            services.AddTransient<IGetOrder, GetOrder>();
            services.AddTransient<IGetTables, GetTables>();
            services.AddTransient<IGetWaiters, GetWaiters>();
            services.AddTransient<IAddOrderArticle, AddOrderArticle>();
            services.AddTransient<IAddOrderAndArticle, AddOrderAndArticle>();
            services.AddTransient<IAddArticleToOrder, AddArticleToOrder>();
            services.AddTransient<IChangeTable, ChangeTable>();
            services.AddTransient<IDecreaseArticlesOrder, DecreaseArticlesOrder>();
            services.AddTransient<IDeleteOrder, DeleteOrder>();
            services.AddTransient<IChangeStatus, ChangeStatus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
