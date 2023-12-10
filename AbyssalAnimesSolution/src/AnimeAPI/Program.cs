using AnimeAPI.Infra.Ioc;
using Microsoft.AspNetCore.Builder;

namespace AnimeAPI;

internal class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddServices(builder.Configuration);
		
		var app = builder.Build();
		
		app.MapGet("/", () => "Hello World!");

		app.Run();
	}
}