using Microsoft.AspNetCore.Authentication.Cookies;
using VottingAPI.Data;
using VottingAPI.Implementation.Repository;
using VottingAPI.Implementation.Services;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VottingAppApiContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IElectoralOfficerService, ElectoralOfficerService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IContestantService, ContestantService>();
builder.Services.AddScoped<IVoteService, VoteService>();
builder.Services.AddScoped<IVoterService, VoterService>();

// Add Repository to the container.
builder.Services.AddScoped<IElectoralOfficerRepository, ElectoralOfficerRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IContestantRepository, ContestantRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();
builder.Services.AddScoped<IVoterRepository, VoterRepository>();
builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
{
    config.LoginPath = "/VottingAPI/AdminLogin";
    config.LoginPath = "/VottingAPI/StudentLogin";
    config.Cookie.Name = "VottingAPI";
    config.LogoutPath = "/VottingAPI/Logout";
});
builder.Services.AddAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
