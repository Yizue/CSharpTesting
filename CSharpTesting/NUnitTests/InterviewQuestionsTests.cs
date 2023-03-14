using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class InterviewQuestionsTests
    {
        public string reverseString(string str)
        {
            char[] chars = str.ToCharArray();
            StringBuilder reverseStr = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseStr.Append(chars[i]);
            }

            return reverseStr.ToString();
        }

        [Test]
        public void ReverseStringTest()
        {
            Assert.AreEqual("gnirtSesrever", reverseString("reverseString"));
        }

        public string reverseWords(string sentence)
        {
            string[] words = sentence.Trim().Split(' ');
            StringBuilder reverseSentence = new StringBuilder();
            Stack<string> st = new Stack<string>();

            foreach (string word in words)
            {
                st.Push(word);
            }

            while (st.Count > 0)
            {
                reverseSentence.Append(st.Pop() + ' ');
            }

            return reverseSentence.ToString().TrimEnd();
        }

        [Test]
        public void ReverseWordsTest()
        {
            Assert.AreEqual("sentence a is This", reverseWords("This is a sentence "));
        }
    }
}
