using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dav_test
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
            services.AddControllersWithViews();
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


                //Make a request for access token
                WebClient client = new WebClient();

        //        string reply =
        //    client.DownloadString(
        //        &@"https://foursquare.com/oauth2/access_token?
        //client_id=ZWZW4WMV13ZIXF1QODU0QNBU2PWNCCTNRA4NQSLREBE41BIY &
        //client_secret=IWQI2YGXNZX21NXAUZRDOLOHZTQVXPH3FHTIWXBETMXAEBFE &
        //grant_type=authorization_code&redirect_uri=http://localhost:51361/home/index&code=" +
        //        Code);

        //        //Deserialize the JSON to get the access token
        //        var jss = new JavaScriptSerializer();
        //        var dict = jss.Deserialize<Dictionary<string, string>>(reply);
        //        //Save the in a session for api endpoints calls
        //        Session["access_token"] = dict["access_token"];

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
