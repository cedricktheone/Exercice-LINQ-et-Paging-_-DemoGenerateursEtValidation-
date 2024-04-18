using DemoGenerateursEtValidation.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MemAutoRep>();

builder.Services.AddDbContext<DbAutoContext>(optionsAction => {
    
    optionsAction.UseSqlServer(builder.Configuration["ConnectionStrings:Cataloguedautos"]);

});

//builder.Services.AddSingleton<IAutoRep, MemAutoRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
InitialiserAuto.Seed(app);

app.Run();
