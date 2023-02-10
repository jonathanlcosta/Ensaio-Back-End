using EnsaioBack.Mapeamentos;
using EnsaioBack.Profiles;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(EnsaiosProfile));
builder.Services.AddScoped<ISessionFactory>(factory => 
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x =>
    {
        x.FluentMappings.AddFromAssemblyOf<EnsaioMap>();
    }).BuildSessionFactory();
    });

    builder.Services.AddScoped<ISession>(factory =>
{
    return factory.GetService<ISessionFactory>()!.OpenSession();
});

var app = builder.Build();
app.UseCors(c =>
{
c.AllowAnyHeader();
c.AllowAnyMethod();
c.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

