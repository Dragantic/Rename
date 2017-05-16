using System.Linq;

namespace Rename
{	public static class Simpler
	{	public static bool In<T>(this T obj, params T[] args)
		{ return args.Contains(obj); }

		public static string Before(this string s, char theChar)
		{	int l = s.IndexOf(theChar);
			if (l > 0) return s.Substring(0, l);
			return "";   }   }   }