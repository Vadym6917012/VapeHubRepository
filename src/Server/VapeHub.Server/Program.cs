using Microsoft.EntityFrameworkCore;
using VapeHub.Server.Core;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v1",
		Title = "VapeHub API",
		Description = "API for VapeHub",
		Contact = new Microsoft.OpenApi.Models.OpenApiContact
		{
			Email = "vadym.radchuk@oa.edu.ua",
			Name = "Vadym Radchuk"
		}
	});
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddCors((setup) =>
{
	setup.AddPolicy("default", (options) =>
	{
		options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
