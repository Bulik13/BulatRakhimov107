using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infa2Semestr.FirstKR;

namespace KRTest
{
    [TestClass]
    public class CollectionTest
    {
        [TestMethod]
        public void TestAdding()
        {
            var x = new LinkedListQueue<int>();
            x.Enqueue(1);
            x.Enqueue(2);
            x.Enqueue(3);
            x.Enqueue(4);
            Assert.AreEqual<string>("2 1 3 4", x.ToString().Trim());
        }
        [TestMethod]
        public void TestDeleting()
        {
            var x = new LinkedListQueue<int>();
            x.Enqueue(1);
            x.Enqueue(3);

            x.Dequeue();

            Assert.AreEqual<string>("3", x.ToString().Trim());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            var x = new LinkedListQueue<int>();
            x.IsEmpty();

            Assert.AreEqual<bool>(string.IsNullOrEmpty(""),x.IsEmpty());
        }

        [TestMethod]
        public void TestSize()
        {
            var x = new LinkedListQueue<int>();

            x.Enqueue(1);
            x.Enqueue(2);

            Assert.AreEqual<int>(2, x.Size());
        }
    }
}
