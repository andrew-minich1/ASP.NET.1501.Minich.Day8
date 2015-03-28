using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearch;

namespace BinarySearchUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string[] arr1 = new string[] { "aa", "ab", "ac", "ad", "ae" };
        int[] arr2 = new int[] { 1, 2, 3, 4, 5 };

        [TestMethod]
        public void BinarySearchTestMethod1()
        {
            Assert.AreEqual(1,SearchAlgoritm.BinarySearch<string>(arr1, "ab", null));
        }

        [TestMethod]
        public void BinarySearchTestMethod2()
        {
            Assert.AreEqual(3,SearchAlgoritm.BinarySearch<int>(arr2, 4, null));
        }

        [TestMethod]
        public void BinarySearchTestMethod3()
        {
            Assert.IsNull(SearchAlgoritm.BinarySearch<int>(arr2, 8, null));
        }
    }
}
