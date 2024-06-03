using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using CaluireMobile._0.Models.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la connexion à la base de données
builder.Services.AddDbContext<CaluireMobileContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("maConnection"),
    new MySqlServerVersion(new Version(8, 0, 31)))); // Adaptez à la version de votre serveur MySQL
builder.Services.AddControllers(
    options => options.ReturnHttpNotAcceptable = true
    )
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache();
builder.Services.AddControllers();

// Lire la configuration
var configuration = builder.Configuration;

// Récupérer la valeur de configuration nécessaire pour Mailjet
var mailjetApiKey = configuration["Mailjet:ApiKey"];
var mailjetApiSecret = configuration["Mailjet:ApiSecret"];
var senderEmailAddress = configuration["Mailjet:SenderEmailAddress"];

if (string.IsNullOrEmpty(mailjetApiKey) || string.IsNullOrEmpty(mailjetApiSecret) || string.IsNullOrEmpty(senderEmailAddress))
{
    throw new ArgumentException("MailjetApiKey, MailjetApiSecret et SenderEmailAddress doivent être configurés.");
}

Console.WriteLine($"Mailjet API Key: {mailjetApiKey}");
Console.WriteLine($"Mailjet API Secret: {mailjetApiSecret}");
Console.WriteLine($"Sender email address: {senderEmailAddress}");

// Ajouter la valeur de configuration au conteneur d'injection de dépendances
builder.Services.AddTransient<IEmailService>(sp => new EmailService(mailjetApiKey, mailjetApiSecret, senderEmailAddress));
builder.Services.AddTransient<ICaluireMobileContext, CaluireMobileContext>();

// Ajout des autres services
builder.Services.AddTransient<IClientsService, ClientsService>();
builder.Services.AddTransient<IProduitsService, ProduitsService>();
builder.Services.AddTransient<IEmployesService, EmployesService>();
builder.Services.AddTransient<IOperationsServices, OperationsServices>();
builder.Services.AddTransient<IPriseEnChargesService, PriseEnChargesService>();
builder.Services.AddTransient<IRendezVousService, RendezVousService>();
builder.Services.AddTransient<ISocketioServices, SocketioServices>();
builder.Services.AddTransient<ITraductionsService, TraductionsService>();
builder.Services.AddTransient<ITraitersService, TraitersService>();
builder.Services.AddTransient<ITransactionspaimentService, TransactionspaimentService>();
builder.Services.AddTransient<ITypesproduitsService, TypesproduitsService>();

// Configuration de Swagger et autres composants d'infrastructure
builder.Services.AddAuthorization();
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

await app.RunAsync();
