using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomCollections;

namespace CustomQueueTestProject
{
    [TestClass]
    public class UnitTest1
    {
        CustomQueue<int> intQueue = new CustomQueue<int>();

        CustomQueue<string> stringQueue = new CustomQueue<string>();

        [TestMethod]
        public void EnqueueTestMethod()
        {
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);
            Assert.AreEqual(intQueue.Size, 5);
        }

        [TestMethod]
        public void PeekTestMethod()
        {
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);
            intQueue.Dequeue();
            Assert.AreEqual(intQueue.Peek(), 2);
        }

        [TestMethod]
        public void DequeueTestMethod()
        {
            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);
            intQueue.Enqueue(4);
            intQueue.Enqueue(5);
            intQueue.Dequeue();
            Assert.AreEqual(intQueue.Size, 4);
        }
    }
}
