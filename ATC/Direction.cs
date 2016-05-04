using System;
using System.Diagnostics;

namespace ATC
{
    public class Direction
    {
        public enum DirectionType
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        };

        public Direction(DirectionType direction)
        {
            this.direction = direction;
        }

        // Read only
        public DirectionType direction { get; private set; }

        public override string ToString()
        {
            return direction.ToString();
        }

        public Direction getOppositeDirection()
        {
            DirectionType dir;
            switch (direction)
            {
                case DirectionType.NORTH:
                    dir = DirectionType.SOUTH;
                    break;
                case DirectionType.SOUTH:
                    dir = DirectionType.NORTH;
                    break;
                case DirectionType.EAST:
                    dir = DirectionType.WEST;
                    break;
                case DirectionType.WEST:
                    dir = DirectionType.EAST;
                    break;
                default:
                    Debug.Assert(false, "INVALID ENUM_VALUE");
                    // ReSharper disable once HeuristicUnreachableCode
                    // It may be unreachable, but C# doesn't get this!
                    throw new NotSupportedException(); 
            }
            return new Direction(dir);
        }
    };
}
