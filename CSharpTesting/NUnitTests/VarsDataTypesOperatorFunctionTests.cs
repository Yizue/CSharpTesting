using NUnit.Framework;
using System;
using System.Text;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class VarsDataTypesOperatorsTests
    {
        // Instantiating C# variables - Primitives
        int i, j;
        double d;
        float f;
        char ch;
        // Objects variables, note: string is a keyword that referts to the String object, they are functionally equivalent
        String aString;
        string theSameString;

        [SetUp]
        public void setUp()
        {
            i = 0; 
            j = 1;
            f = 2.3f;
            ch = 'a';
            aString = "";
        }

        [TearDown]
        public void tearDown()
        {

        }

        [Test]
        public void VariableTest()
        {
            Assert.AreEqual(i + j, 1);
        }

        [Test]
        public void PassByValueVsReference()
        {
            var x = 3; // Dynamically defined type - type is found in runtime, cannot define this dynamically as a class variable
            String str = "myString";

            // Call method and modify both params
            modifyVars(x, ref str);

            // Expect primitive to remain unchanged, while Object is modified
            Assert.AreEqual(3, x);
            Assert.AreEqual("myString added", str);
        }

        [Test]
        public void OutKeyword()
        {
            d = 1.4;
            double outVar;

            d = outResult(d, out outVar);

            // Double AreEqual will not work, use overloaded third argument to passin EPSILON difference precision double is 15 digits
            Assert.AreEqual(1.4d, d, 0.000000000000001);
            Assert.AreEqual(14.8d, outVar, 0.000000000000001); // outVar has value passed back by outResult Method
            // Similarly, double equality == will not work for similar reasons
        }

        [Test]
        public void DefineStringAsObject()
        {
            string s1 = "hello";

            char[] ch = { 'c', 's', 'h', 'a', 'r', 'p' };
            string s2 = new String(ch);

            Assert.AreEqual("hello", s1);
            Assert.AreEqual("csharp", s2);
        }

        [Test]
        public void UsingStringMethods()
        {
            string s1 = "TestingString";
            string s2 = "TestingMyString";

            Assert.AreEqual(1, string.Compare(s1, s2)); // since M > S lexicographically, returns 1
            /* compares strings lexicographically: 
             * s1 == s2 returns 0
             * s1 > s2 returns 1
             * s1 < s2 returns -1
             */
            Assert.AreEqual("A string", string.Concat("A ", "string"));

            Assert.AreEqual(true, s1.Contains("ting"));
            Assert.AreEqual(false, s1.Contains("Ting")); // case sensitive

            string s3 = "Testing String X";
            string[] splitStr = s3.Split(' '); // Pass delimiter char
            Assert.AreEqual("X", splitStr[2]);

            Assert.AreEqual("STRING", splitStr[1].ToUpper());
            Assert.AreEqual("string", splitStr[1].ToLower());

            Assert.AreEqual("String", s1.Substring(7)); // [7, end] string
            Assert.AreEqual("Str", s1.Substring(7, 3)); // [7, 7+3) string (second param is length)

            Assert.AreEqual("TestingWing", s1.Replace("Str", "W"));

            Assert.AreEqual("Spacey String", " Spacey String  ".Trim()); // Also TrimStart() and TrimEnd()
        }

        [Test]
        public void UsingStringInterpolation()
        {
            string name = "Mark";
            var date = new DateTime(2023, 3, 5);

            string str = $"Hello, {name}! Today is {date.DayOfWeek}, it's {date.Year}/{date.Month}/{date.Day} now.";
            Assert.AreEqual("Hello, Mark! Today is Sunday, it's 2023/3/5 now.", str);
        }


        // StringBuilder - Represents a mutable string of characters. Use this when you want to modify a string very often
        // (since String is immutable and must be replaced on every modification)
        [Test]
        public void UsingStringBuilder()
        {
            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            StringBuilder sb = new StringBuilder("ABC", 50);

            // Append three characters (D, E, and F) to the end of the StringBuilder.
            sb.Append(new char[] { 'D', 'e', 'F' });

            // Append a format string to the end of the StringBuilder.
            sb.AppendFormat("GHI{0}{1}", 'j', 'k');

            // Insert a string at the beginning of the StringBuilder.
            sb.Insert(0, "Alphabet: ");

            // Replace all lowercase k's with uppercase K's.
            sb.Replace('k', 'K');

            // Removes from startindex number of chars equal to length specified
            sb.Remove(0, 5); 

            Assert.AreEqual(16, sb.Length);
            Assert.AreEqual("bet: ABCDeFGHIjK", sb.ToString());
        }

        #region Helper Methods
        public void modifyVars(int i, ref String s) // Ref keyword used to make the parameter pass by reference
        {
            i++; // Increment operator, if ++i, assignment comes before return of value
            s += " added";
        }

        public double outResult(double i, out double j) // Out keyword effectively similar to ref, except that it does not require variable to initialize before passing
        {
            j = i + 3 * 2; // Arithmetic Operations, also - , % , /  order of operations is PEMDAS like
            j *= 2; // Shorthand assignment operatior, also +=, -=, etc.
            return i--; // This will return value of i not the decremented value!
        }
        #endregion
    }
}
