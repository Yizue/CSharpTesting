using NUnit.Framework;
using OpenQA.Selenium.DevTools.V108.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpTesting.NUnitTests.ExceptionHandlingTests;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class CollectionsAndGenericsTests
    {
        /*
         * Generic is a concept that allows us to define classes and methods with placeholder. 
         * C# compiler replaces these placeholders with specified type at compile time. 
         * The concept of generics is used to create general purpose classes and methods. 
         * To define generic class, we must use angle <> brackets. The angle brackets are used to declare a class or method as generic type. 
         * In the following example, we are creating generic class that can be used to deal with any type of data.
         */
        class GenericClass<T>
        {
            public GenericClass(T msg)
            {
                Console.WriteLine(msg);
            }
        }
        //Example Creating Object with given type for generic:

        //GenericClass<string> gen = new GenericClass<string>("This is generic class");

        // In C#, collection represents group of objects. 
        // All the data structure work can be performed by C# collections.
        [Test]
        public void UsingList()
        {
            var names = new List<string>() {"Sonoo", "Vimal"}; // Initializing block
            names.Add("Irfan");
            names.Insert(0, "Steve"); // Insert into a given index
            names.Remove("Irfan"); // Remove first occurrence of given item

            // Iterate through the list.  
            foreach (var name in names)
            {
                //Console.WriteLine(name);
            }

            Assert.AreEqual(3, names.Count);
            Assert.AreEqual(2, names.FindIndex(x => x.Contains("mal"))); // Pass anonymous function -> Predicate for this method

            names.Sort((a, b) => a.CompareTo(b)); // ascending order, flip the compare to b -> a for descending

            Assert.AreEqual("Sonoo", names[0]);
            Assert.AreEqual("Steve", names[1]);
        }

        //C# HashSet class can be used to store, remove or view elements. It does not store duplicate elements.
        //It is suggested to use HashSet class if you have to store only unique elements. 
        // ALT: SortedSet<> for instances when you want the set to be sorted (always ascending order)
        [Test]
        public void UsingHashSet()
        {
            var names = new HashSet<string>() { "Sonoo", "Ankit", "Peter", "Irfan" };
            names.Add("Steve");

            // Iterate through the list.  
            foreach (var name in names)
            {
                //Console.WriteLine(name);
            }

            Assert.AreEqual(5, names.Count);
            Assert.AreEqual(true, names.Contains("Steve"));
        }

        //C# Stack as expected -> LIFO setup
        [Test]
        public void UsingStack()
        {
            Stack<string> names = new Stack<string>();
            names.Push("Sonoo");
            names.Push("Peter");
            names.Push("James");
            names.Push("Ratan");
            names.Push("Irfan");

            Assert.AreEqual("Irfan", names.Peek());
            Assert.AreEqual("Irfan", names.Pop()); // Pop returns item and removes item from end
            Assert.AreEqual("Ratan", names.Peek());
        }

        //C# Queue as expected -> FIFO setup
        [Test]
        public void UsingQueue()
        {
            Queue<string> names = new Queue<string>();
            names.Enqueue("Sonoo");
            names.Enqueue("Peter");
            names.Enqueue("James");
            names.Enqueue("Ratan");
            names.Enqueue("Irfan");

            Assert.AreEqual("Sonoo", names.Peek());
            Assert.AreEqual("Sonoo", names.Dequeue()); // Dequeue returns item and removes item from beginning
            Assert.AreEqual("Peter", names.Peek());
        }

        [Test]
        public void UsingLinkedList()
        {
            LinkedList<string> names = new LinkedList<string>();
            names.AddLast("Sonoo"); // Add to last index
            names.AddLast("Peter");
            names.AddFirst("Irfan"); // Add to first index

            //insert new element before and after "Peter"  
            LinkedListNode<String> node = names.Find("Peter");
            names.AddBefore(node, "John");
            names.AddAfter(node, "Lucy");

            Assert.AreEqual("Irfan", names.ElementAt(0));
            Assert.AreEqual("Sonoo", names.ElementAt(1));
            Assert.AreEqual("John", names.ElementAt(2));
            Assert.AreEqual("Peter", names.ElementAt(3));
            Assert.AreEqual("Lucy", names.ElementAt(4));
        }

        //C# Dictionary<TKey, TValue> class uses the concept of hashtable.
        //It stores values on the basis of key. It contains unique keys only. By the help of key, we can easily search or remove elements.
        [Test]
        public void UsingDictionary()
        {
            Dictionary<int, string> names = new Dictionary<int, string>
            {
                { 1, "Sonoo" },
                { 2, "Peter" },
                { 3, "James" }
            };
            names.Add(6, "Irfan");

            int count = 0;
            string str = "";

            foreach (KeyValuePair<int, string> kv in names)
            {
                count += kv.Key;
                str += kv.Value[0];
            }

            Assert.AreEqual(12, count);
            Assert.AreEqual("SPJI", str);
        }
    }
}
