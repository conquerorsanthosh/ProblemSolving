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

		//source :copied from educative.io for practice purpose.
		public static  int GetLongestSubstrwithSameLettersAfterReplacement(string str,int k) 
		{
			int windowStart = 0, maxLength = 0, maxRepeatLetterCount = 0;
			Dictionary<char, int> letterFrequencyMap = new Dictionary<char, int>();
			// try to extend the range [windowStart, windowEnd]
			for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
			{
				char rightChar = str[windowEnd];
				if(!letterFrequencyMap.ContainsKey(rightChar))
					letterFrequencyMap[rightChar] = 0;
				letterFrequencyMap[rightChar] += 1;
				maxRepeatLetterCount = Math.Max(maxRepeatLetterCount, letterFrequencyMap[rightChar]);

				// current window size is from windowStart to windowEnd, overall we have a letter which is
				// repeating 'maxRepeatLetterCount' times, this means we can have a window which has one letter 
				// repeating 'maxRepeatLetterCount' times and the remaining letters we should replace.
				// if the remaining letters are more than 'k', it is the time to shrink the window as we
				// are not allowed to replace more than 'k' letters
				if (windowEnd - windowStart + 1 - maxRepeatLetterCount > k)
				{
					Console.WriteLine("reducing the window size");
					char leftChar = str[windowStart];
					letterFrequencyMap[leftChar]+= - 1;
					windowStart++;
				}

				maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
				Console.WriteLine("start=" + windowStart);
				Console.WriteLine("end=" + windowEnd);
				Console.WriteLine("maxRepeatLetterCount=" + maxRepeatLetterCount);
				Console.WriteLine("maxLength=" + maxLength);
				
				foreach (KeyValuePair<char, int> kvp in letterFrequencyMap)
				{
					//textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
					Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
				}
				Console.WriteLine("####################");
			}
			return maxLength;
		}
	}
}
