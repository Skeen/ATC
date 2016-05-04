namespace ATC
{
    public class Track
    {
        public Track(int speed, Direction direction, string tag, Position position)
        {
            this.speed = speed;
            this.direction = direction;
            this.tag = tag;
            this.position = position;
            this.destination = new Position(0, 0);
        }

        // Get the distance that we'll have traveled using the current speed on 'delta_time'.
        public double get_distance_at_current_speed(int delta_time)
        {
            // Find the speed in nautical miles per millisecond.
            double nmiles_per_minute = (double)speed / 60;
            double nmiles_per_second = nmiles_per_minute / 60;
            double nmiles_per_millisecond = nmiles_per_second / 1000;
            // Get the knots we've moved ahead
            double movement_nmiles = nmiles_per_millisecond * delta_time;
            // And return it
            return movement_nmiles;
        }

        // Update the position, by advancing delta_time milliseconds
        // * delta_time (milliseconds)
        public void update(int delta_time)
        {
            double movement_nmiles = get_distance_at_current_speed(delta_time);
            // Advance the track
            position = advance_position_by_direction(position, direction, movement_nmiles);
        }

        public static Position advance_position_by_direction(Position position, Direction direction, double distance)
        {
            // Move that amount of knots in the correct direction
            switch (direction.direction)
            {
                case Direction.DirectionType.NORTH:
                    position.y = position.y + distance;
                    break;
                case Direction.DirectionType.EAST:
                    position.x = position.x + distance;
                    break;
                case Direction.DirectionType.SOUTH:
                    position.y = position.y - distance;
                    break;
                case Direction.DirectionType.WEST:
                    position.x = position.x - distance;
                    break;
            }
            return position;
        }

        public override string ToString()
        {
            return tag + " at " + position + " going " + direction.direction.ToString() + " at " + speed + "knots aiming for " + destination;
        }

        // speed (in knots, which is 1 nautical mile/hr or 1.852 km/hr)
        public int speed { get; set; }
        // direction - (x,y) increments
        public Direction direction { get; set; }
        // tag / name - (unique name) - readonly
        public string tag { get; private set; }
        // position - (x,y) - readonly
        public Position position { get; private set; }
        // destination - (x,y)
        public Position destination { get; set; }
    }
}