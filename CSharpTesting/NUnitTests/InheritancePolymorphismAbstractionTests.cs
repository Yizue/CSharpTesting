using NUnit.Framework;
using System;

/*
 * C# Namespaces
 * Namespaces in C# are used to organize too many classes so that it can be easy to handle the application.
 * In a simple C# program, we use System.Console where System is the namespace and Console is the class. 
 * To access the class of a namespace, we need to use namespacename.classname. We can use using keyword so that we don't have to use complete name all the time.
 * In C#, global namespace is the root namespace. The global::System will always refer to the namespace "System" of .Net Framework.
 */
namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class InheritancePolymorphismAbstractionTests
    {
        public class Owner
        {
            public string name, address;

            public Owner()
            {
                this.name = "Steve";
                this.address = "A1";
            }
            public Owner(string name, string address)
            {
                this.name = name;
                this.address = address;
            }
        }

        public class Animal
        {
            public string Name { get; set; }
            public string Color;
            public Owner owner; // Aggregation, this class HAS-AN object - owner

            public Animal() 
            {
                owner = new Owner();
                Color = "This animal's color: ";
            }

            public int eat(int val) { return val - 1; }

            public int eat(int val1, int val2) { return val1 - val2; } // overloading methods in same class

            public virtual string eat(string val) { return val + " eaten"; } // Virtual method, to be overriden in base class
        }
        public class Dog : Animal // Inheritance - inherits the parent's methods and fields
        {
            public string Color; // Child and Parent has same named field, use base keyword to access parent's specifically (super in js)
            public Dog(string n, string c) // Child's constructor internally invokes the parent's constructor
            {
                Name = n;
                this.Color = c;
            }

            public string bark() { return Name + " barked!"; }

            public override string eat(string val) { return "Doggo " + Name + " ate " + val; } // overriding method, will call this method and not the parent one

            public string eat(string val, int count) { return count.ToString() + " " + val + " eaten"; } // overloading methods in child class

            public string getColor() { return base.Color + this.Color; }
        }

        /* 
         * C# sealed keyword applies restrictions on the class and method. 
         * If you create a sealed class, it cannot be derived. If you create a sealed method, it cannot be overridden.
         * Note: Structs are implicitly sealed therefore they can't be inherited.
         */
        sealed public class Species
        {
            public void eat() { Console.WriteLine("eating..."); }
        }

        /*
         * Abstract classes are the way to achieve abstraction in C#. 
         * Abstraction in C# is the process to hide the internal details and showing functionality only. Abstraction can be achieved by two ways:
            Abstract class
            Interface
        */
        public abstract class Shape
        {
            /*
             * A method which is declared abstract and has no body is called abstract method. 
             * It can be declared inside the abstract class only. Its implementation must be provided by derived classes
             */
            public abstract string draw(); 
        }
        public class Rectangle : Shape
        {
            public override string draw()
            {
                return "Drew Rectangle"; 
            }
        }

        /*
         * Interface in C# is a blueprint of a class. It is like abstract class because all the methods which are declared inside the interface are abstract methods. 
         * It cannot have method body and cannot be instantiated.
         * It is used to achieve multiple inheritance which can't be achieved by class. It is used to achieve fully abstraction because it cannot have method body.
         */
        public interface Drawable
        {
            //string shape; No fields allowed
            //Note: Interface methods are public and abstract by default. You cannot explicitly use public and abstract keywords for an interface method.
            string draw();
        }
        public class Circle : Drawable // This class is implementing Drawable, it must have all the methods that interface specifies
        {
            private int Radius { get; set; }

            public Circle(int radius)
            {
                this.Radius = radius;
            }

            public string draw()
            {
                return "Drew Circle of radius: " + Radius;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        [Test]
        public void UsingInheritedClasses()
        {
            Dog a1 = new Dog("Terrier", "brown"); 
            Animal a2 = new Dog("Labrador", "blonde"); // Can also use Polymorphism here to assign a Dog Object to Animal (parent) Type
            a2.owner.name = "New Owner"; // Accessing object under another object

            Assert.AreEqual(3, a2.eat(4)); // Call parent method
            Assert.AreEqual("Terrier barked!", a1.bark()); // Call child method
            Assert.AreEqual("New Owner", a2.owner.name);

            Assert.AreEqual("This animal's color: brown", a1.getColor());
            //Assert.AreEqual("This animals color: blonde", a2.getColor()); // Cannot call getColor here because a2 is type Animal, not Dog!
        }

        [Test]
        public void UsingOverloadedandOverrridenMethods()
        {
            Dog a1 = new Dog("Terrier", "brown");
            Animal a2 = new Dog("Labrador", "blonde"); // Can also use Polymorphism here to assign a Dog Object to Animal (parent) Type

            Assert.AreEqual(5, a1.eat(7, 2)); // Call overloaded parent method
            Assert.AreEqual("Doggo Terrier ate apple", a1.eat("apple")); // Call overriden parent method - polymorphism: child type so calls child's method
            Assert.AreEqual("3 apples eaten", a1.eat("apples", 3)); // Call overloaded child method

            Assert.AreEqual("Doggo Labrador ate apple", a2.eat("apple")); // Call overriden parent method - polymorphism: parent type, still calls child's method
        }

        [Test]
        public void UsingAbstractionDerivedClasses()
        {
            Shape s1 = new Rectangle();
            Drawable s2 = new Circle(6); 

            Assert.AreEqual("Drew Rectangle", s1.draw());
            Assert.AreEqual("Drew Circle of radius: 6", s2.draw());

            //Assert.AreEqual(6, s2.Radius); Since s2 is type drawable, not Circle, cant access Radius directly
        }
    }
}
