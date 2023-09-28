using System.Text.Json.Serialization;
using ManageSchool_API.Data;
using ManageSchool_API.SchoolClasroom.Services;
using ManageSchool_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions
                (x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Dependency Injection
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SchoolService>();
builder.Services.AddScoped<SchoolClassroomService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<SchoolSubjectService>();
builder.Services.AddScoped<SchoolGradesService>();
builder.Services.AddScoped<CalculateGradesService>();

var app = builder.Build();

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
