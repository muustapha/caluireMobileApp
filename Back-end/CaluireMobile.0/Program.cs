using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la connexion à la base de données
builder.Services.AddDbContext<CaluireMobileContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("maConnection"),
    new MySqlServerVersion(new Version(8, 0, 31)))); // Remplacez 8, 0, 31 par la version de votre serveur MySQL
builder.Services.AddControllers(
    options => options.ReturnHttpNotAcceptable = true
    )
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache(); // Ajoute cela pour activer le caching
builder.Services.AddControllers();

// Lire la configuration
var configuration = builder.Configuration;

// Récupérer la valeur de configuration nécessaire
var sendGridApiKey = configuration.GetSection("SendGridApiKey").Value;
var senderEmailAddress = configuration.GetSection("SenderEmailAddress").Value;

// Ajouter la valeur de configuration au conteneur d'injection de dépendances
builder.Services.AddTransient<EmailService>(sp => new EmailService(sendGridApiKey, senderEmailAddress));

// Ajout des services
builder.Services.AddTransient<ClientsService>();
builder.Services.AddTransient<EmployesService>();
builder.Services.AddTransient<OperationsServices>();
builder.Services.AddTransient<RendezVousService>();
builder.Services.AddTransient<PriseEnChargesService>();
builder.Services.AddTransient<SocketioServices>();
builder.Services.AddTransient<ProduitsService>();
builder.Services.AddTransient<TraductionsService>();
builder.Services.AddTransient<TraitersService>();
builder.Services.AddTransient<TypesproduitsService>();
builder.Services.AddTransient<TransactionspaimentService>();

// Ajout du service d'autorisation
builder.Services.AddAuthorization();

// Configuration de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CaluireMobile", Version = "v1" });
});

var app = builder.Build();

// Configuration de l'environnement de développement
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaluireMobile v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
endpoints.MapControllers();
});

app.Run();