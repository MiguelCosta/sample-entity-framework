using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace NinjaDomain.DataModel
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                //.AddSqlite()
                .AddSqlServer()
                .AddDbContext<NinjaContext>(
                        options =>
                        {
                            //options.UseSqlite("Filename=./ninja.db");
                            options.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=NinjaDB;Trusted_Connection=true;MultipleActiveResultSets=true;");
                        }
                );
        }
    }
}
