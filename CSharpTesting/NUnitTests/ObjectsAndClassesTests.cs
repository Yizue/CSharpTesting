using NUnit.Framework;
using System;

namespace CSharpTesting.NUnitTests
{
    public class Student // Define a class
    {
        int id;//field or data member -private access by default
        public String name;//field or data member - public access 

        static public int studentCount = 0; // Static field Not tied to specific object, but to the class itself

        static Student() // Static constructors are called once always before any instances of that class exist, used to set static field amounts for the class
        {
            studentCount = 0;
        }

        public Student() // Default Constructor
        {
            id = 0;
            name = "";
            studentCount++;
        }

        public Student(int uID, String uName) // Parametrized Constructor, class can have multiple overloaded constructors
        {
            insertData(uID, uName);
            studentCount++;
        }

        ~Student() // Desctructor, called automatically when class is destroyed, only 1 in class and is always private
        {
            //Console.WriteLine("Destructor Invoked");
        }

        public void insertData(int uID, String uName) // define method in class, public access 
        {
            this.id = uID; // This keyword is optional
            name = uName;
        }

        public int getID ()
        {
            return this.id;
        }

        public string address; // Note: Need to define another field when not using the default accessors
        public string Address // Defining class property with getter and setter methods defined using get and set keywords
        {
            get { return address; } set { address = value; }
        }

        public string Name2 { get; set; } // short hand for default accessors - BOTH of these setups provides inbuilt support for Encapsulation in C#
    }

    /* 
     * The C# static class is like the normal class but it cannot be instantiated. 
     * It can have only static members. The advantage of static class is that it provides you guarantee that instance of static class cannot be created.
     */
    public static class MyMath
    {
        public static float PI = 3.14f;
        public static int cube(int n) { return n * n * n; }
    }

    /*
     * In C#, classes and structs are blueprints that are used to create instance of a class. 
     * Structs are used for lightweight objects such as Color, Rectangle, Point etc.
     * Unlike class, structs in C# are VALUE TYPE than reference type. It is useful if you have data that is not intended to be modified after creation of struct. 
     */
    public struct Rectangle
    {
        public int width, height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public int getArea()
        {
            return width * height;
        }
    }

    /*
     * Enum in C# is also known as enumeration. It is used to store a set of named constants such as season, days, month, size etc. 
     * The enum constants are also known as enumerators. Enum in C# can be declared within or outside class and structs.
     * Enum constants has default values which starts from 0 and incremented to one by one. But we can change the default value.
     */
    public enum Season { WINTER=1, SPRING, SUMMER, FALL } // Winter = 1 changes the start index to 1 from 0

    [TestFixture]
    public class ObjectsAndClassesTests
    {
        [Test, Order(1)]
        public void CreateObjFromClass()
        {
            Student s1 = new Student(); //creating an object of Student (default constructor)   

            s1.name = "Steve H"; // Public access, can assign value to it directly

            Assert.AreEqual("Steve H", s1.name);

            s1.insertData(1, "myName");

            Assert.AreEqual(1, s1.getID());
            Assert.AreEqual("myName", s1.name);
        }

        [Test, Order(2)]
        public void CreateObjFromClassUsingConstructor()
        {
            Student s2 = new Student(2, "theirName"); //creating an object of Student (parametrized constructor)   

            Assert.AreEqual(2, s2.getID());
            Assert.AreEqual("theirName", s2.name);
        }

        [Test, Order(3)]
        public void StaticFieldsAndFunctions()
        {
            Student s3 = new Student(); //Third student created

            Assert.AreEqual(3, Student.studentCount); // Shows that class amount itself will not reset until finished run of entire TestFixture
            Assert.AreEqual(27, MyMath.cube(3));
        }

        [Test, Order(4)]
        public void Structs()
        {
            Rectangle r = new Rectangle(4, 5); //Third student created

            Assert.AreEqual(20, r.getArea());
        }

        [Test, Order(5)]
        public void Enums()
        {
            string seasons = "";
            foreach (string s in Enum.GetNames(typeof(Season))) // Type of Enum elements is string, but is associated with a index number
            {
                seasons += s + " ";
            }

            Assert.AreEqual("WINTER SPRING SUMMER FALL ", seasons);
            Assert.AreEqual(1, (int)Season.WINTER);
            Assert.AreEqual(2, (int)Season.SPRING);
            Assert.AreEqual(3, (int)Season.SUMMER);
            Assert.AreEqual(4, (int)Season.FALL);
        }

        [Test, Order(5)]
        public void Properties()
        {
            Student s4 = new Student();

            s4.Address = "A1 South Street"; // Setter

            Assert.AreEqual("A1 South Street", s4.Address); // Getter
        }
    }
}
