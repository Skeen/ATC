using System;

namespace ATC
{
    public class Position
    {
        // Copy-constructor
        public Position(Position p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x.ToString("N") + ", " + y.ToString("N") + ")";
        }

        // Get the distance between two positions
        public static double get_distance(Position p1, Position p2)
        {
            double x_offset = p2.x - p1.x;
            double y_offset = p2.y - p1.y;
            
            double x_offset_squared = x_offset * x_offset;
            double y_offset_squared = y_offset * y_offset;

            return Math.Sqrt(x_offset_squared + y_offset_squared);
        }

        public double x { get; set; }
        public double y { get; set; }
    }
}
