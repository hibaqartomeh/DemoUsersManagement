using DemoUsMange.Abstraction;
using DemoUsMange.Domain;
using DemoUsMange.Infrastructuer;
using DemoUsMange.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<DemoUsMange.Infrastructure.Persistence.ApplicationDbContext>(options =>
options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
builder.Services.AddScoped<IEventStore, EventStore>();
//builder.Services.AddScoped<IInvitation, Invitation>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<InvitationMemberService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
