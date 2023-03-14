using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTesting.NUnitTests
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void SimpleArray()
        {
            int[] arr = new int[5]; // creating simple array  
            int[] arr2 = new int[] { 10, 20, 30, 40, 50 }; // Alt ways to initialize an array
            int[] arr3 = { 10, 20, 30, 40, 50 }; // Only works in declaration line

            arr[2] = 20;  // initializing an element in the array  

            Assert.AreEqual(0, arr[0]); // uninitialized array value is default value for given primitive - 0 for int
            Assert.AreEqual(20, arr[2]);
            Assert.AreEqual(90, arr2[4] + arr3[3]);

            int j = 0;
            foreach (int i in arr3) // Use foreach keyword to traverse an array, i is value for a given element
            {
                Assert.AreEqual(10 * (++j), i);
            }
        }

        [Test]
        public void PassArrayToFunction()
        {
            int[] arr = new int[] { 4, 2, 3, 1, 9 };

            int minValue = ArrayTests.printMin(arr);  

            Assert.AreEqual(1, minValue);
        }

        [Test]
        public void TwoDand3DArrays()
        {
            int[,] arr2D = new int[3, 3];//declaration of 2D array  
            int[,,] arr3D = new int[3, 3, 3];//declaration of 3D array  

            arr2D[0, 1] = 10; //initialization  
            arr2D[1, 2] = 20;
            arr2D[2, 0] = 30;

            arr2D = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // Alternate initialization
            int[,] arr2DAlt = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // Only works in declaration line

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(arr2D[i, j], arr2DAlt[i, j]);
                }
            }
        }

        [Test]
        public void ArrayOfArrays()
        {
            int[][] arr = new int[2][]; // An Array of Arrays

            arr[0] = new int[] { 1, 2, 5, 7 }; // Size of each element can be different lengths
            arr[1] = new int[] { 4, 6, 3, 4, 5, 6 };

            int[] flatArr = new int[] { 0, 0 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    flatArr[i] += arr[i][j];
                }
            }

            Assert.AreEqual(15, flatArr[0]);
            Assert.AreEqual(28, flatArr[1]);
        }

        [Test]
        public void ParamsKeyword()
        {
            string[] arr = { "A", "nice", "hat" };

            Assert.AreEqual("A nice hat ", concatString(arr)); // Can pass in as an array
            Assert.AreEqual("A very nice hat ", concatString("A", "very", "nice", "hat")); // Can pass in as any numbers of elements directly
        }

        [Test]
        public void ArrayClassMethods()
        {
            // Creating an array  
            int[] arr = new int[6] { 5, 8, 9, 25, 0, 7 };
            // Creating an empty array  
            int[] arr2 = new int[6];
 
            Assert.AreEqual(6, arr.Length);  // Length of arr

            // Sorting array (smallest to greatest)
            Array.Sort(arr);

            int num = -1;
            foreach(int i in arr)
            {
                Assert.LessOrEqual(num, i);
                num = i;
            }
                
            // Finding index of an array element  
            Assert.AreEqual(5, Array.IndexOf(arr, 25));

            // Coping first array to empty array  
            Array.Copy(arr, arr2, arr.Length);

            Assert.AreEqual(arr[4], arr2[4]);
            Assert.NotZero(arr2[4]);
        }

        #region Helper Methods
        static int printMin(int[] arr) // pass in array as argment for this method
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            return min;
        }

        public string concatString(params string[] strs) // Params Paramater -  can pass in indefined # of elemnts in a given array
        {
            string s = "";
            foreach (string str in strs)
            {
                s += str + " ";
            }
            return s;
        }
        #endregion
    }
}
