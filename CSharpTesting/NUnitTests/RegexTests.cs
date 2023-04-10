using NUnit.Framework;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class RegexTests
    {
        [Test]
        public void UsingRegexObject()
        {
            string patternText = "Hello";
            Regex reg = new Regex(patternText); // Create Regex object with specified regex, can be just a string as is

            //IsMatch(string input) - finds if regex is found within string
            //Console.WriteLine(reg.IsMatch("Hello World"));
            Assert.AreEqual(true, reg.IsMatch("Hello World"));

            //IsMatch(string input, int index) - returns true if can find a match starting from given index
            //Console.WriteLine(reg.IsMatch("Hello", 0));
            Assert.AreEqual(false, reg.IsMatch("Oh Hello World", 4));

            //IsMatch(string input, string pattern) - static version
            //Console.WriteLine(Regex.IsMatch("Hello World", patternText));
            Assert.AreEqual(true, Regex.IsMatch("Hello World", "llo"));

            //Replace(string input, string replacement) - replace substrings
            //Console.WriteLine(reg.Replace("Hello World", "Replaced"));
            Assert.AreEqual("Oh Hi World", reg.Replace("Oh Hello World", "Hi"));

            //Replace(string input, string replacement) - replace substrings static version
            Assert.AreEqual("Oh Yeah World", Regex.Replace("Oh Hello World", "Hello", "Yeah"));

            //Split(string input, string pattern)
            string[] arr = Regex.Split("Hello_World_Today", "_");
            /*foreach (string subStr in arr)
            {
                Console.WriteLine("{0}", subStr);
            }*/
            Assert.AreEqual("World", arr[1]);
        }

        [Test]
        public void ComposingRegexPatterns()
        {
            Regex reg1 = new Regex(@"^[D]"); // ^ - starts with following char

            Regex reg2 = new Regex(@"[d]$"); // $ - ends with previous char

            Assert.AreEqual(false, reg1.IsMatch("Hello World"));
            Assert.AreEqual(true, reg2.IsMatch("Hello World"));

            // NOTE: Use @ at front to allow usage of special characters without having to escaping it
            Regex reg3 = new Regex(@"[\s]*"); // [\s] whitespace, * denotes presence of any amount of preceding char INCLUDING 0
            Regex reg4 = new Regex(@"[\d]+[\w]{5}"); // [\d] numerals, [\w] alphanumerics and _,
                                                     // + denotes 1 or more of preceding char, {n} denotes exactly n times of preceding char

            Assert.AreEqual(true, reg3.IsMatch("Hello   World"));
            Assert.AreEqual(true, reg3.IsMatch("HelloWorld")); // 0 counts too!

            Assert.AreEqual(false, reg4.IsMatch("Hello World"));
            Assert.AreEqual(true, reg4.IsMatch("43110World"));

            //NOTE: do not add space between {n, m} -> this does not work
            Regex reg5 = new Regex(@"[A-Za-z]{5,9}[0-9]?"); // [A-Za-z] letters (upper/lower), [0-9] numerals
                                                             // ? denotes 0 or 1 of preceding char, {n,m} denotes range of n to m times of preceding char present
                                                             // Also can do {n,} to denote a floor of n but no upper limit

            Assert.AreEqual(false, reg5.IsMatch("Hell0Worl6"));
            Assert.AreEqual(true, reg5.IsMatch("elloWorld"));
            Assert.AreEqual(true, reg5.IsMatch("elloWorl0"));

            Regex reg6 = new Regex(@"[^A-Za-z0-9]{3,}"); // [^...] Denotes negation of block - this patter will match all non-alphanumeric values
            Assert.AreEqual(false, reg6.IsMatch("Hell0Worl6"));
            Assert.AreEqual(true, reg6.IsMatch("%ah$ .my, ;"));
        }
    }
}
