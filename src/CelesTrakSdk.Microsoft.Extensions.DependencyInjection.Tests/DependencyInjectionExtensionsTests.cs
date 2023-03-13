using CelesTrakSdk.Microsoft.Extensions.DependencyInjection.DependencyInjection;
using CelesTrakSdk.Public.Clients;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;


namespace CelesTrakSdk.Microsoft.Extensions.DependencyInjection.Tests;

public class DependencyInjectionExtensionsTests
{
	[Fact]
	public void CanGetClientFromServiceProvider()
	{
		IServiceCollection collection = new ServiceCollection();
		_ = collection.AddCelesTrakServices();

		ServiceProvider provider = collection.BuildServiceProvider();
		ICelesTrakClient? client = provider.GetService<ICelesTrakClient>();

		client.ShouldNotBeNull();
	}
}
