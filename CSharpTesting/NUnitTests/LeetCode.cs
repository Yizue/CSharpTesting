﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class LeetCode
    {
        public static string FizzBuzz(int endNum)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 1; i <= endNum; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    s.Append("fizzbuzz" + " ");
                else if (i % 3 == 0)
                    s.Append("fizz" + " ");
                else if (i % 5 == 0)
                    s.Append("buzz" + " ");
                else
                    s.Append(i);
            }

            return s.ToString();
        }

        public IList<string> FizzBuzzList(int n)
        {
            List<string> s = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    s.Add("FizzBuzz");
                else if (i % 3 == 0)
                    s.Add("Fizz");
                else if (i % 5 == 0)
                    s.Add("Buzz");
                else
                    s.Add(i.ToString());
            }

            return s;
        }

        public IList<string> FizzBuzzListAlt1(int n)
        {
            List<string> s = new List<string>();

            s = Enumerable.Range(1, n).Select(i => (i % 3 == 0 && i % 5 == 0 ? "FizzBuzz" : i % 3 == 0 ? "Fizz" : i % 5 == 0 ? "Buzz" : i.ToString())).ToList();

            return s;
        }

        // Extendable solution
        public IList<string> FizzBuzzListMap(int n)
        {
            var map = new Dictionary<int, string>
            {
                //{3*5*7, "FizzBuzzWoof"}, // Optional
                //{5*7, "BuzzWoof"}, // Optional
                //{3*7, "FizzWoof"}, // Optional
                {3*5, "FizzBuzz"},
                //{7, "Woof"},
                {5, "Buzz"},
                {3, "Fizz"},
                {1, null} // For all numbers not evenly divisible
            };

            var words = Enumerable
                .Range(1, n)
                .Select(i => (map[map.Keys.First(k => i % k == 0)]) ?? i.ToString());

            // string.Join(' ', words).Dump("Result");
            return words.ToList();         
        }

        public bool IsPalindrome(string s)
        {
            bool isP = true;

            Regex r = new Regex("[^A-Za-z0-9]");

            s = r.Replace(s, "").ToLower();

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] == s[j])
                    continue;
                else
                {
                    isP = false;
                    break;
                }
            }

            return isP;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = (list1.val <= list2.val ? list1 : list2);
            ListNode temp;

            while (list1 != null && list2 != null)
            {
                if (list1 == null)
                {
                    list2 = list2.next;
                }
                else if (list2 == null)
                {
                    list1 = list1.next;
                }
                else if (list1.val <= list2.val)
                {
                    if (list1.next == null)
                    {
                        list1.next = list2;
                    }
                    else if (list1.next.val <= list2.val)
                    {
                        list1 = list1.next;
                    }
                    else
                    {
                        temp = list1.next;
                        list1.next = list2;
                        list1 = temp;
                    }
                }
                else
                {
                    if (list2.next == null)
                    {
                        list2.next = list1;
                    }
                    if (list2.next.val <= list1.val)
                    {
                        list2 = list2.next;
                    }
                    else
                    {
                        temp = list2.next;
                        list2.next = list1;
                        list2 = temp;
                    }
                }
            }
            return head;
        }

        public int RemoveDuplicates(int[] nums)
        {
            int count = 0;
            ISet<int> set = new HashSet<int>();

            foreach (int i in nums)
            {
                if (set.Add(i))
                    count++;
                nums[count - 1] = i;
            }

            return count;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            if (strs.Length == 1)
                return strs[0];

            string b = strs[0];
            if (b.Length == 0)
            {
                return "";
            }

            int count = Math.Max(b.Length, 0);

            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length == 0)
                {
                    count = 0;
                    break;
                }
                count = Math.Min(count, strs[i].Length);
                for (int j = 0; j <= count; j++)
                {
                    if (strs[i][j] != b[j])
                    {
                        count = j;
                        break;
                    }
                }
                if (count == 0) break;
            }
            if (count == 0) return "";
            return b.Substring(0, count);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            int[] sol = { 0, 1 };
            
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            sol[0] = i;
                            sol[1] = j;
                            return sol;
                        }
                    }
                }
            }

            return sol;
        }

        public int MajorityElement(int[] nums)
        {
            HashSet<int> unique = new HashSet<int>();

            foreach (int i in nums)
                unique.Add(i);

            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (int j in unique)
                counts.Add(j, 0);

            foreach (int k in nums)
                counts[k]++;

            int majority = nums[0];
            int cutoff = Convert.ToInt32(Math.Ceiling(nums.Length/2.0));

            foreach (int l in unique)
            {
                if (counts[l] >= cutoff)
                {
                    majority = l;
                    break;
                }
            }

            return majority;
        }

        public bool IsValidParenthesis(string s)
        {
            Stack<char> st = new Stack<char>();

            if (s.Length == 0) return true;
            foreach (var ch in s)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    st.Push(ch);
                }
                else
                {
                    char expectedOpenBracket;
                    try
                    {
                        expectedOpenBracket = st.Pop();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }

                    if (expectedOpenBracket == '(' && ch == ')')
                    {
                        continue;
                    }
                    else if (expectedOpenBracket == '[' && ch == ']')
                    {
                        continue;
                    }
                    else if (expectedOpenBracket == '{' && ch == '}')
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (st.Count > 0) return false;
            return true;
        }

        public int StrStr(string haystack, string needle)
        {
            var match = Regex.Match(haystack, needle);
            if (match.Success) return match.Index;
            return -1;
        }

        public bool IsPowerOfThree(int n)
        {
            if (n <= 0) return false;
            var exp = Math.Log(n, 3);
            var res = Math.Abs(Math.Round(exp) - exp);
            return res < 0.00000000000001 ? true : false;
        }

        [Test]
        public void LeetCodeTester()
        {
            var x = IsPowerOfThree(59049);
            var y = IsPowerOfThree(45);
            Assert.AreEqual(true, x);
            Assert.AreEqual(false, y);
        }
    }
}