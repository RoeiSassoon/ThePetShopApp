using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<FileService>();

string IdentfiyconnectionString = builder.Configuration["ConnectionStrings:UserDb"]!;
builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(IdentfiyconnectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();
string AnimalconnectionString = builder.Configuration["ConnectionStrings:AnimalDb"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseSqlServer(AnimalconnectionString));
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
var app = builder.Build();

if(app.Environment.IsStaging()|| app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}    

using (var scope = app.Services.CreateScope())
{
    var animalDb = scope.ServiceProvider.GetRequiredService<PetShopContext>(); 
    var UserDb = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    UserDb.Database.EnsureDeleted();
    UserDb.Database.EnsureCreated();
    animalDb.Database.EnsureDeleted();
    animalDb.Database.EnsureCreated();
}
app.UseAuthentication();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("Home", "{controller=Home}/{action=HomePage}/{id?}");
app.Run();
