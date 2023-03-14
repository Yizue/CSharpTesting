using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTesting.NUnitTests
{
    delegate int Calculator(int n); //declaring delegate  

    [TestFixture]
    public class DelegatesReflectionAnonFuncsTests
    {
        //In C#, delegate is a reference to the method. It works like function pointer in C and C++. But it is objected-oriented, secured and type-safe than function pointer.

        //The best use of delegate is to use as event.

        static int number = 100;

        public static int add(int n)
        {
            number = number + n;
            return number;
        }
        public static int mul(int n)
        {
            number = number * n;
            return number;
        }

        [Test]
        public void UsingDelegates()
        {
            Calculator c1 = new Calculator(add);//instantiating delegate using the add and mul methods
            Calculator c2 = new Calculator(mul);
            
            c1(20); //calling method using delegate  
            Assert.AreEqual(120, number);
            c2(3);
            Assert.AreEqual(360, number);
        }

        /*
         * In C#, reflection is a process to get metadata of a type at runtime. The System.Reflection namespace contains required classes for reflection such as Type
         * C# Type class represents type declarations for class types, interface types, enumeration types, array types, value types etc. 
         */
        [Test]
        public void UsingReflection()
        {
            int a = 10;
            Type typeA = a.GetType(); // One way to get type obj

            Assert.AreEqual("System.Int32", typeA.ToString());

            Type typeStr = typeof(System.String);
            Assert.AreEqual("System.String", typeStr.FullName);
            Assert.AreEqual("System.Object", typeStr.BaseType.FullName); // Parent Class, returns Type
            Assert.AreEqual(true, typeStr.IsClass);
            Assert.AreEqual(false, typeStr.IsEnum);
            Assert.AreEqual(false, typeStr.IsInterface);
        }

        /*
         * Anonymous function is a type of function that does not has name. In other words, we can say that a function without name is known as anonymous function.
         * In C#, there are two types of anonymous functions:
            Lambda Expressions
            Anonymous Methods - Anonymous method provides the same functionality as lambda expression, except that it allows us to omit the parameter list. 
         */
        delegate int Square(int num); // Define delegate to hold anon functions
        public delegate string AnonymousFun();

        [Test]
        public void UsingAnonymousFunctions()
        {          
            Square GetSquare = x => x * x; // Lambda expression () => {}

            Assert.AreEqual(25, GetSquare(5));

            AnonymousFun fun = delegate () { // Anon Method: delegate () {}
                return "This is anonymous function";
            };

            Assert.AreEqual("This is anonymous function", fun());
        }
    }
}
