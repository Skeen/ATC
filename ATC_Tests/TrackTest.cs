using ATC;

namespace ATC_Tests
{
    using NUnit.Framework;

    [TestFixture]
    class TrackTest
    {
        [Test]
        public void constructionTest()
        {
            Track t = new Track(100, new Direction(Direction.DirectionType.WEST), "TestMagic", new Position(2, 5));

            Assert.AreEqual(100, t.speed);
            Assert.AreEqual(Direction.DirectionType.WEST, t.direction.direction);
            Assert.AreEqual("TestMagic", t.tag);
            Assert.AreEqual(2, t.position.x);
            Assert.AreEqual(5, t.position.y);
        }

        [Test]
        public void toStringTest()
        {
            Track t = new Track(100, new Direction(Direction.DirectionType.WEST), "TestMagic", new Position(2, 5));
            string str = t.ToString();
            const string expected = "TestMagic at (2,00, 5,00) going WEST at 100knots aiming for (0,00, 0,00)";

            Assert.AreEqual(expected, str);
        }

        [Test]
        public void distanceTraveledTest()
        {
            const int delta_time = 1000;

            Track t = new Track(100, new Direction(Direction.DirectionType.WEST), "TestMagic", new Position(2, 5));
            double movement_nmiles = t.get_distance_at_current_speed(delta_time);
            const double expected_result = 100D / 60 / 60 / 1000 * delta_time;

            Assert.AreEqual(expected_result, movement_nmiles, 0.001);
        }

        [Test]
        public void advancePositionTest()
        {
            Position position1 = Track.advance_position_by_direction(new Position(0, 0), new Direction(Direction.DirectionType.EAST), 1);
            Assert.AreEqual(1, position1.x);
            Assert.AreEqual(0, position1.y);

            Position position2 = Track.advance_position_by_direction(new Position(3, -5), new Direction(Direction.DirectionType.NORTH), 7);
            Assert.AreEqual(3, position2.x);
            Assert.AreEqual(2, position2.y);

            Position position3 = Track.advance_position_by_direction(new Position(0, 0), new Direction(Direction.DirectionType.WEST), -1);
            Assert.AreEqual(1, position3.x);
            Assert.AreEqual(0, position3.y);
        }

        [Test]
        public void updateTest()
        {
            const int delta_time = 1000;

            Track t1 = new Track(100, new Direction(Direction.DirectionType.NORTH), "TestMagic", new Position(0, 0));
            t1.update(delta_time);

            Assert.AreEqual(0, t1.position.x);
            Assert.AreEqual(0.027, t1.position.y, 0.001);

            Track t2 = new Track(300, new Direction(Direction.DirectionType.NORTH), "TestMagic", new Position(5, 10));
            t2.update(delta_time);

            Assert.AreEqual(5, t2.position.x);
            Assert.AreEqual(10.083, t2.position.y, 0.001);
        }
    }
}
