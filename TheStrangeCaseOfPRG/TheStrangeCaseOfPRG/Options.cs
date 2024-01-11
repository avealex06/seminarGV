using System;
namespace TheStrangeCaseOfPRG
{
	public class Options
	{

		public string text { get; }
		public Options previous { get; }
		public List<Options> next { get; }
		public Options(string text, Options previous = null )
		{
			this.text = text;
			this.previous = previous;
			next = new List<Options>();
		}

		public void AddNext(Options next)
		{
			this.next.Add(next);
		}
		
	}
}

