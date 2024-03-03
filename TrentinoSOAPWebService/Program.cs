using TrentinoClassLibrary.Service;
using TrentinoClassLibrary.Abstraction;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSoapCore();
builder.Services.AddScoped<ITrentinoService, TrentinoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.UseSoapEndpoint<ITrentinoService>
               ("/TrentinoService.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer));

app.UseAuthorization();

app.MapRazorPages();

app.Run();