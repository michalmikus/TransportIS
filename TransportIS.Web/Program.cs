using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportIS.BL.Repository;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.DAL;
using TransportIS.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services,builder.Configuration);

var app = builder.Build();

Configure(app);

app.Run();

static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
{
    var dbConnectionString = configuration.GetConnectionString("db");

    if(string.IsNullOrEmpty(dbConnectionString))
    {
        throw new InvalidOperationException("No connection string.");
    }

    var contextOptionsBuilder = new DbContextOptionsBuilder<TransportISDbContext>()
#if DEBUG
    .UseLoggerFactory(LoggerFactory.Create(a => a.AddConsole()))
        .EnableSensitiveDataLogging()
#endif
    .UseSqlServer(dbConnectionString);

    services.AddTransient(sp => contextOptionsBuilder.Options);
    services.AddDbContext<TransportISDbContext>(ServiceLifetime.Transient);
    services.AddIdentity<UserEntity, RoleEntity>()
       .AddEntityFrameworkStores<TransportISDbContext>()
       .AddDefaultTokenProviders();


    services.AddTransient<Func<TransportISDbContext>>(sp => () => sp.GetRequiredService<TransportISDbContext>());

    AddRepositories(services);
    
    services.AddControllers();

}


static void Configure(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseEndpoints(endpoints => endpoints.MapControllers());
}

static void AddRepositories(IServiceCollection services)
{
    var repositoryType = typeof(ConnectionRepository);

    services.Scan(scan =>
       scan.FromAssembliesOf(repositoryType)
       .AddClasses(s => s.AssignableTo(repositoryType))
       .AsImplementedInterfaces()
       .AsSelf());
}