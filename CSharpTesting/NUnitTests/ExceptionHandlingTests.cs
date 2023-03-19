using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class ExceptionHandlingTests
    {
        [Test]
        public void TryCatchFinallyBlock()
        {
            bool finallyExecuted = false;

            try
            {
                int a = 10;
                int b = 0;
                int x = a / b;
            }
            catch (Exception e) { Assert.AreEqual(true, e is System.DivideByZeroException); } // Catched exceptions go into e
            finally { finallyExecuted = true; } // Always executed

            Assert.AreEqual(true, finallyExecuted);
        }

        // Defining a custom exception, inherit relevant Exception (or one of its child) class
        public class InvalidAgeException : Exception
        {
            public InvalidAgeException(String message)
                : base(message) {}
        }

        static void validate(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Sorry, Age must be greater than 18");
            }
        }

        [Test]
        public void UsingUserDefinedExceptions()
        {
            try
            {
                validate(17);
            }
            catch (Exception e) { 
                Assert.AreEqual(true, e is InvalidAgeException);
                Assert.AreEqual("Sorry, Age must be greater than 18", e.Message);
            }
        }

        // The checked keyword is used to explicitly check overflow and conversion of integral type values at compile time.
        // The Unchecked keyword ignores the integral type arithmetic exceptions. It does not check explicitly and will allow underflow/overflow results through
        [Test]
        public void UsingCheckedAndUncheckedKeyword()
        {
            unchecked // If checked was here instead, it would throw an unhandled exception here
            {
                int val = int.MaxValue;
                Assert.AreEqual(-2147483647, val + 2); // overflow
            }
        }
    }
}
