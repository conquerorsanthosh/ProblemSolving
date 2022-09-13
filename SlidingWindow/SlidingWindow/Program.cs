using System;
using System.Collections.Generic;

namespace SlidingWindow
{
	class Program
	{
		static void Main(string[] args)
		{
			//HashSet<string> result= GetAllSubstringWithKDistinctChars("abcbacabaccxzabc", 4);
			//Console.WriteLine(SlidingWindowsProblems.GetMaxLenSubstringWithKRepeatingCharacters("aaabbccddeeffaaaggghk", 2));
			//foreach (string s in result) Console.WriteLine(s);
			SlidingWindowsProblems.GetLongestSubstrwithSameLettersAfterReplacement("aabbcceecc", 2);
			Console.ReadLine();
		}

		//source="abcbacabacc" K=3  output:'abc' cba bac cab 
		public static HashSet<string> GetAllSubstringWithKDistinctChars(string source, int kdistinct)
		{
			HashSet<string> result = new HashSet<string>();
			List<char> klenSubstr = new List<char>();
			int count = 0;
			int start = 0;
			int end = 0;


			while (end <= source.Length - 1)
			{
				//keep adding to hashset until there is a collistion
				if (!klenSubstr.Contains(source[end]) && klenSubstr.Count <= kdistinct)
				{
					klenSubstr.Add(source[end]);
					end++;
					if (klenSubstr.Count == kdistinct)
					{
						if (!result.Contains(string.Join("", klenSubstr.ToArray())))
						{
							result.Add(string.Join("", klenSubstr.ToArray()));
						}
					}
				}

				else
				{
					while (klenSubstr.Contains(source[end]))
					{
						klenSubstr.Remove(source[start]);
						start++;
					}
					klenSubstr.Add(source[end]);
					end++;
				}
			}
			return result;
		}
	}
}
