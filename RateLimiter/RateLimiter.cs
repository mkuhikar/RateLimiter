using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateLimiterProject
{
	public class RateLimiter
	{
		private int limit;
		private int windowSize;
		private Queue<DateTime> requests;
		public RateLimiter(int limit, int windowSize)
		{
			this.limit = limit;
			this.windowSize = windowSize;
			this.requests = new Queue<DateTime>();
		}
		public bool IsRequestAllowed()
		{
			DateTime now = DateTime.Now;
			DateTime windowStart = now.AddSeconds(-windowSize);
			
			if(requests.Count < limit)
			{
				requests.Enqueue(now);
				return true;
			}
			else if (requests.Peek() > windowStart)
			{
				return false;
			}
			else
			{
				requests.Dequeue();
				requests.Enqueue(now);
				return true;
			}
		}
	}
	
}
