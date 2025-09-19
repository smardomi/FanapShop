using Fanap.Shop.API.Configurations;
using Fanap.Shop.Appliction.Features.Invoices.Commands.CreateInvoice;
using Fanap.Shop.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices()
                .AddJwt()
                .AddSwagger()
                .AddInfrastruncture()
                .AddHttpContextAccessor()
                .AddControllers();


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(CreateInvoiceCommand).Assembly);
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(dbContext);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FanapShop API V1");
    });
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
