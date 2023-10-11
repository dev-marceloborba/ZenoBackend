using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Scan(
    selector => selector
        .FromAssemblies(
            Datacenter.Infrastructure.AssemblyReference.Assembly,
            Datacenter.Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
   
builder.Services.AddMediatR(Datacenter.Application.AssemblyReference.Assembly);

builder
    .Services
    .AddControllers()
    .AddApplicationPart(Datacenter.Presentation.AssemblyReference.Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();