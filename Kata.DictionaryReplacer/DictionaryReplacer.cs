using System;
using System.Collections.Generic;
using NUnit.Framework;

using dict = System.Collections.Generic.Dictionary<string, string>;

namespace Kata.DictionaryReplacer
{

	public class DictionaryReplacer
	{
		static string Replace (string input, int i, int length, string replaceWith)
		{
			if (i == 0) 
			{
				return replaceWith + input.Substring (i + length);
			}
			else if (i > 0) 
			{
				return input.Substring (0, i) + replaceWith + input.Substring (i + length);
			}

			return input;
		}

		static string FindAndReplace (string input, string find, string with)
		{
			int i;

			do 
			{
				i = input.IndexOf (find, StringComparison.CurrentCultureIgnoreCase);
				input = Replace (input, i, find.Length, with);
			}
			while (i >= 0);

			return input;
		}

		public static string Replace(string input, Dictionary<string, string> replacements)
		{
			foreach (var item in replacements) 
            {
				input = FindAndReplace (input, "$" + item.Key + "$", item.Value);
			}

			return input;
		}
	}
}
