using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Asegurarse de que la configuración esté completamente disponible
var configuration = builder.Configuration;

// Leer el proveedor de base de datos desde appsettings.json
string databaseProvider = configuration.GetValue<string>("DatabaseType");

if (databaseProvider == "SQLServer")
{
    builder.Services.AddScoped<IClienteDataAccessLayer, ClienteSqlDataAccessLayer>();
}
else if (databaseProvider == "Postgres")
{
    builder.Services.AddScoped<IClienteDataAccessLayer, ClientePostgresDataAccessLayer>();
}
else
{
    throw new InvalidOperationException("Proveedor de base de datos no soportado");
}

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar la canalización de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();