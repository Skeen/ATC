using System;
using ATC;

namespace ATC_Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void constructionTest()
        {
            const int num_iterations = 100;

            Random rand = new Random();
            for (int i = 0; i < num_iterations; i++)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                Position postition = new Position(x, y);

                Assert.AreEqual(x, postition.x);
                Assert.AreEqual(y, postition.y);

                Position copy = new Position(postition);

                Assert.AreEqual(x, copy.x);
                Assert.AreEqual(y, copy.y);
            }
        }

        [Test]
        public void distanceTest()
        {
            Position postition1 = new Position(0, 0);
            Position postition2 = new Position(1, 2);

            Assert.AreEqual(2.236, Position.get_distance(postition1, postition2), 0.001);

            Position postition3 = new Position(8, 5);
            Position postition4 = new Position(3, 11);

            Assert.AreEqual(7.810, Position.get_distance(postition3, postition4), 0.001);
        }

        [Test]
        public void setTest()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            // In order to use the set syntax
            Position postition1 = new Position(0, 0);
            postition1.x = 100;
            postition1.y = 20;

            Assert.AreEqual(100, postition1.x);
            Assert.AreEqual(20, postition1.y);

            Position postition2 = new Position(0, 0) {x = 100, y = 20};

            Assert.AreEqual(100, postition2.x);
            Assert.AreEqual(20, postition2.y);
        }

        [Test]
        public void toStringTest()
        {
            Position postition1 = new Position(7, 5);
            string str1 = postition1.ToString();
            const string expected1 = "(7,00, 5,00)";
            Assert.AreEqual(expected1, str1);

            Position postition2 = new Position(100.2529, 0.6443);
            string str2 = postition2.ToString();
            const string expected2 = "(100,25, 0,64)";
            Assert.AreEqual(expected2, str2);
        }
    }
}
