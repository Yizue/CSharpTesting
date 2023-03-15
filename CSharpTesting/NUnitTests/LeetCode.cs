﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpTesting
{
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
                    s.Append(i.ToString());
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
    }
}