using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBTree;
using System.Collections.Generic;

namespace RBTUnitTesting
{
    [TestClass]
    public class RBTreeTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var tree = new Tree();
            Assert.IsNotNull(tree);
            tree = new Tree(1);
            Assert.IsNotNull(tree);
        }

        [TestMethod]
        public void TestInsert()
        {
            var tree = new Tree();
            var expectedValues = new List<int>();
            tree.Insert(1);            
            for (int i = 0; i < 1000; i++)
            {
                tree.Insert(i);
                expectedValues.Add(i);
            }
            var count = tree.Count;
            Assert.AreEqual(1000, count);
            var values = tree.GetOrderedValues();
           
            CollectionAssert.AreEquivalent(expectedValues, values);
        }
    }
}
