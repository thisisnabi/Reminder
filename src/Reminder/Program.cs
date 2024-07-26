using Reminder;

var builder = WebApplication.CreateBuilder(args);

builder.BrokerConfigure();
builder.DbContextConfigure();
builder.Services.Configure<ReminderOptions>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
 
 
app.Run();
 