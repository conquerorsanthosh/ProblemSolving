using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindow
{
	public static class SlidingWindowsProblems
	{

		/*
		 
		 source=aaabbccddeeffaaaggghk" ,kdistinct=2
		possible candidates= "aaabb","bbcc","ccdd", "ddee" ,"eeff" ,"ffaaa", aaaggg 
		winner:aaaggg
		length=6
		 */

		public static int GetMaxLenSubstringWithKRepeatingCharacters(string source, int kdistinct)
		{
			int start = 0;
			int end = 0;
			string maxLenString;
			int maxLength = 0;
			Dictionary<char, int> charFrequency = new Dictionary<char, int>();
			while (end <= source.Length - 1)
			{
				if (!charFrequency.ContainsKey(source[end]))
				{
					charFrequency[source[end]] = 0;
				}
				charFrequency[source[end]] += 1;

				if (charFrequency.Count == kdistinct)
				{
					maxLength = Math.Max(maxLength, end - start + 1);
				}

				else
				{
					while (charFrequency.Count > kdistinct)
					{
						charFrequency[source[start]] += -1;
						if (charFrequency[source[start]] == 0)
						{
							charFrequency.Remove(source[start]);
						}
						start++;
					}
				}
				end++;
			}
			return maxLength;
		}
	}
}
