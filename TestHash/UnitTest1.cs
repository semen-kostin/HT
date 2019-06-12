using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static HT.Program;

namespace TestHash
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HashTestAdd3Find3()
        {
            var hash = new HashTable(3);

            var element1 = 88;
            var element2 = new[] { 1, 2, 3, 4 };
            var element3 = "value";

            hash.PutPair(0, element1);
            hash.PutPair(42, element2);
            hash.PutPair("key", element3);


            Assert.AreEqual(element1, hash.GetValueByKey(0));
            Assert.AreEqual(element2, hash.GetValueByKey(42));
            Assert.AreEqual(element3, hash.GetValueByKey("key"));
        }

        [TestMethod]
        public void HashTestAddSameKeyTwice()
        {
            var hash = new HashTable(2);

            var key = 42;
            var element1 = 666;
            var element2 = 88;

            hash.PutPair(key, element1);
            hash.PutPair(key, element2);

            Assert.AreEqual(element2, hash.GetValueByKey(key));
        }

        [TestMethod]
        public void HashTestAdd10000Find1()
        {
            var size = 10000;
            var rnd = new Random();
            int findKey = 0;
            int findElement = 0;
            int flag = rnd.Next(size);

            var hash = new HashTable(size);

            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                var key = rnd.Next();
                hash.PutPair(key, element);

                if (i == flag)
                {
                    findElement = element;
                    findKey = key;
                }
            }
            Assert.AreEqual(findElement, hash.GetValueByKey(findKey));
        }

        [TestMethod]
        public void HashTestAdd10000Find1000Null()
        {
            var size = 10000;
            var rnd = new Random();
            int flag = rnd.Next(size);

            var hash = new HashTable(size);

            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                hash.PutPair(i, element);
            }

            for (var i = 0; i < 1000; i++)
                Assert.AreEqual(null, hash.GetValueByKey(rnd.Next(1000) + 10000));
        }
    }
}
