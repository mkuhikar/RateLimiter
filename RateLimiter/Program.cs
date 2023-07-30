
namespace RateLimiterProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Create a rate limiter with a limit of 5 requests per second
			RateLimiter rateLimiter = new RateLimiter(5, 1);

			// Simulate some requests
			for (int i = 0; i < 20; i++)
			{
				if (rateLimiter.IsRequestAllowed())
				{
					Console.WriteLine("Request allowed");
				}
				else
				{
					Console.WriteLine("Request blocked");
				}

				// Sleep for 200 milliseconds between requests
				Thread.Sleep(100);
			}
		}
	}
}