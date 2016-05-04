using ATC;

namespace ATC_Tests
{
    using NUnit.Framework;

    [TestFixture]
    class DirectionTest
    {
        [Test]
        public void constructionTest()
        {
            Direction direction = new Direction(Direction.DirectionType.NORTH);
            Assert.AreEqual(Direction.DirectionType.NORTH, direction.direction);
        }

        [Test]
        public void oppositeDirectionTest()
        {
            Direction direction1 = new Direction(Direction.DirectionType.NORTH);
            Direction opposite1 = direction1.getOppositeDirection();
            Assert.AreEqual(Direction.DirectionType.SOUTH, opposite1.direction);

            Direction direction2 = new Direction(Direction.DirectionType.EAST);
            Direction opposite2 = direction2.getOppositeDirection();
            Assert.AreEqual(Direction.DirectionType.WEST, opposite2.direction);
        }

        [Test]
        public void toStringTest()
        {
            Direction direction1 = new Direction(Direction.DirectionType.NORTH);
            string str1 = direction1.ToString();
            Assert.AreEqual("NORTH", str1);

            Direction direction2 = new Direction(Direction.DirectionType.WEST);
            string str2 = direction2.ToString();
            Assert.AreEqual("WEST", str2);
        }
    }
}
