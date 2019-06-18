using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RAApplication.ICommands;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.ICommands.ICommandsArticleType;
using RAApplication.ICommands.ICommandsAuth;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.ICommands.ICommandsRole;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Interfaces;
using RAApplication.Login;
using RACommands;
using RACommands.ArticleCommands;
using RACommands.ArticleTypeCommands;
using RACommands.AuthCommands;
using RACommands.OrderCommands;
using RACommands.RoleCommands;
using RACommands.TableCommands;
using RACommands.WaiterCommands;
using RestaurantApi.Email;
using RestaurantApi.Helpers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace RestaurantApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<RestaurantContext>();
            services.AddTransient<IGetRestaurantSectors, GetRestaurantSectors>();
            services.AddTransient<IAddRestaurantSector, AddRestaurantSector>();
            services.AddTransient<IGetRestaurantSector, GetRestaurantSector>();
            services.AddTransient<IDeleteRestaurantSector, DeleteRestaurantSector>();
            services.AddTransient<IUpdateRestaurantSector, UpdateRestaurantSector>();
            services.AddTransient<IGetArticleTypes, GetArticleTypes>();
            services.AddTransient<IGetArticleType, GetArticleType>();
            services.AddTransient<IAddArticleType, AddArticleType>();
            services.AddTransient<IUpdateArticleType, UpdateArticleType>();
            services.AddTransient<IDeleteArticleType, DeleteArticleType>();
            services.AddTransient<IGetTable, GetTable>();
            services.AddTransient<IAddTable, AddTable>();
            services.AddTransient<IGetRoles, GetRoles>();
            services.AddTransient<IGetRole, GetRole>();
            services.AddTransient<IAddRole, AddRole>();
            services.AddTransient<IUpdateRole, UpdateRole>();
            services.AddTransient<IDeleteRole, DeleteRole>();
            services.AddTransient<IGetTables, GetTables>();
            services.AddTransient<IDeleteTable, DeleteTable>();
            services.AddTransient<IUpdateTable, UpdateTable>();
            services.AddTransient<IGetWaiter, GetWaiter>();
            services.AddTransient<IGetWaiters, GetWaiters>();
            services.AddTransient<IAddWaiter, AddWaiter>();
            services.AddTransient<IDeleteWaiter, DeleteWaiter>();
            services.AddTransient<IUpdateWaiter, UpdateWaiter>();
            services.AddTransient<IGetArticle, GetArticle>();
            services.AddTransient<IGetArticles, GetArticles>();
            services.AddTransient<IDeleteArticle, DeleteArticle>();
            services.AddTransient<IUpdateArticle, UpdateArticle>();
            services.AddTransient<IAddArticle, AddArticle>();
            services.AddTransient<IAddOrderArticle, AddOrderArticle>();
            services.AddTransient<IGetOrders, GetOrders>();
            services.AddTransient<IAddArticleToOrder, AddArticleToOrder>();
            services.AddTransient<IAddOrderAndArticle, AddOrderAndArticle>();
            services.AddTransient<IGetOrder, GetOrder>();
            services.AddTransient<IChangeStatus, ChangeStatus>();
            services.AddTransient<IChangeTable, ChangeTable>();
            services.AddTransient<IDecreaseArticlesOrder, DecreaseArticlesOrder>();
            services.AddTransient<IDeleteOrder, DeleteOrder>();
            services.AddTransient<IGetLoggedUser, GetLoggedUser>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var section = Configuration.GetSection("Email");

            var sender =
                new EmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);
          

            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Substring(0, decodedString.LastIndexOf("}") + 1);
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseStaticFiles();
            app.UseMvc();    
        }
    }
}