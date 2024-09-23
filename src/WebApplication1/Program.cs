using Lib.AspNetCore.ServerSentEvents;
using WebApplication1.Sse;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddServerSentEvents();
builder.Services.AddServerSentEvents<INotificationsServerSentEventsService, NotificationsServerSentEventsService>();

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

app.MapServerSentEvents("/default-sse-endpoint");
app.MapServerSentEvents<NotificationsServerSentEventsService>("/notifications-sse-endpoint");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
