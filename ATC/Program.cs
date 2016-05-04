using System;
using System.Diagnostics;

namespace ATC
{
    class Program
    {
        private const int number_of_tracks = 10;
        private const double tick_length = 1;

        // Get a direction from an index
        private static Direction.DirectionType get_direction_type(int index)
        {
            switch (index)
            {
                case 0:
                    return Direction.DirectionType.NORTH;
                case 1:
                    return Direction.DirectionType.EAST;
                case 2:
                    return Direction.DirectionType.SOUTH;
                case 3:
                    return Direction.DirectionType.WEST;
                default:
                    Debug.Assert(false, "ARGUMENT OUT OF BOUNDS");
                    // ReSharper disable once HeuristicUnreachableCode
                    // It may be unreachable, but C# doesn't get this!
                    throw new NotSupportedException(); 
            }
        }

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedParameter.Local
        // This is goddamn main, has to be like this!
        static void Main(string[] args)
        {
            Random rnd = new Random();

            ATC_System atc = new ATC_System();
            for (int x = 0; x < number_of_tracks; x++)
            {
                // Get a random speed
                int speed = rnd.Next(400, 480);
                // Get a random direction
                int direction_index = rnd.Next(0, 4);
                Direction.DirectionType direction = get_direction_type(direction_index);
                // Get a random position
                int x_coord = rnd.Next(-400, 400);
                int y_coord = rnd.Next(-400, 400);
                Position position = new Position(x_coord, y_coord);
                // Make our track
                Track t = new Track(speed, new Direction(direction), "FLIGHT" + x, position);
                // And add it
                atc.handle_incoming_track(t);
            }
            while (atc.handles_tracks())
            {
                atc.tick(tick_length);
            }
        }
    }
}
