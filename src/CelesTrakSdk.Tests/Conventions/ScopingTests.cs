using System.Reflection;
using System.Runtime.CompilerServices;
using CelesTrakSdk.Public.Models;
using Shouldly;
using Xunit;

namespace CelesTrakSdk.Tests.Conventions;

public class ScopingTests
{
	private const string InternalNameSpaceFragment = "CelesTrakSdk.Internal";
	private const string PublicNamespaceFragment   = "CelesTrakSdk.Public";
    
	[Theory]
	[MemberData(nameof(NamespaceClassDataGenerator), InternalNameSpaceFragment)]
	public void ClassesInInternalsNamespaceAreNotPublic(Type type)
	{
		type.IsPublic.ShouldBeFalse();
	}
	
	[Theory]
	[MemberData(nameof(NamespaceClassDataGenerator), PublicNamespaceFragment)]
	public void ClassesInPublicNamespaceArePublic(Type type)
	{
		type.IsPublic.ShouldBeTrue();
	}


	public static IEnumerable<object[]> NamespaceClassDataGenerator(string namespaceFragment) => typeof(SatCatRecord).Assembly.GetTypes()
																									.Where(t => t.Namespace != null && t.Namespace.Contains(namespaceFragment))
																									.Where(t => t.GetCustomAttribute<CompilerGeneratedAttribute>() is null)
																									.Select(t => new object[] {t});
}
