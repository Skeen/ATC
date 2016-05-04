using ATC;
using ATC.Utility;

namespace ATC_Tests
{
    using NUnit.Framework;

    [TestFixture]
    class PairTest
    {
        [Test]
        public void constructionTest()
        {
            Pair<int, int> int_pair = new Pair<int, int>(5, 3);
            Assert.AreEqual(5, int_pair.first);
            Assert.AreEqual(3, int_pair.second);

            Pair<double, int> double_int_pair = new Pair<double, int>(14.523, 4);
            Assert.AreEqual(14.523, double_int_pair.first, 0.0001);
            Assert.AreEqual(4, double_int_pair.second);
        }

        [Test]
        public void setTest()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            // Using wierd intialization for the purpose of testing.
            Pair<char, int> pair = new Pair<char, int>('A', 4);
            pair.first = 'C';
            pair.second = -3;
            Assert.AreEqual('C', pair.first);
            Assert.AreEqual(-3, pair.second);
        }
    }
}
