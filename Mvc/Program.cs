using Hangfire;
using Microsoft.EntityFrameworkCore;
using Mvc;
using Mvc.Models;
using Mvc.Repository;
using Mvc.Services;
using Mvc.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var cons = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
builder.Services.AddHangfire(config => config
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(cons));
builder.Services.AddHangfireServer();
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(cons));
builder.Services.AddTransient<IRepository<Request>, Repository<Request>>();
builder.Services.AddSingleton<IFileWriter, FileWriter>();
builder.Services.AddScoped<IJob, Job>();




var app = builder.Build();
app.UseHangfireDashboard();
app.MapHangfireDashboard();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

BackgroundJob.Enqueue<IJob>(x => x.GetFireandForget());
BackgroundJob.Schedule<IJob>(x => x.GetDelayFilesFiles(), TimeSpan.FromMinutes(1));
RecurringJob.AddOrUpdate<IJob>(x => x.GetRecursiveFiles(), Cron.MinuteInterval(2));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Request}/{action=Index}/{id?}");

app.Run();
