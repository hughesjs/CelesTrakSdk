namespace CelesTrakSdk.Internal.Extensions;

// Attr: https://stackoverflow.com/a/63757293/4700841
public static class AsyncEnumerableExtensions
{
	public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> items, CancellationToken cancellationToken = default)
	{
		List<T> results = new();
		await foreach (T item in items.WithCancellation(cancellationToken))
		{
			results.Add(item);
		}
		return results;
	}
}
