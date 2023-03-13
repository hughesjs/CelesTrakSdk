using CelesTrakSdk.Internal.Clients;
using CelesTrakSdk.Public.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace CelesTrakSdk.Microsoft.Extensions.DependencyInjection.DependencyInjection;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddCelesTrakServices(this IServiceCollection services)
	{
		services.AddHttpClient<ICelesTrakClient, CelesTrakClient>(h => h.BaseAddress = new("https://celestrak.org/"));

		return services;
	}
}
