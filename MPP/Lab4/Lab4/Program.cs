using BL.Implementations;
using BL.Interfaces;
using DAL.Data;
using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

const string projectName = "Lab4";
const string progressConnectionStringProperty = "ProgressDb";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString(progressConnectionStringProperty)!;
builder.Services.AddDbContext<ProgressDbContext>(options => options.UseSqlite(connectionString, 
    optionsBuilder => optionsBuilder.MigrationsAssembly(projectName)));
builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<IFacultyManager, FacultyManager>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IGroupManager, GroupManager>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectManager, SubjectManager>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddControllersWithViews();

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

app.Run();