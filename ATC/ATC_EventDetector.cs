using System.Collections.Generic;
using ATC.Utility;

namespace ATC
{
    // ReSharper disable once InconsistentNaming
    // Exercise requires this.
    class ATC_EventDetector
    {
        private const double mid_air_distance = 5;
        private const double near_miss_distance = 10;
        private const double at_distination_distance = 5;

        private bool is_closer_than(Position p1, Position p2, double test_distance)
        {
            // Get the distance between these
            double distance = Position.get_distance(p1, p2);
            // Return true, if this distance is less than the near_miss distance
            return (distance < test_distance);
        }

        // Return true, if the two tracks are closer than 'test_distance'
        private bool is_closer_than(Track t1, Track t2, double test_distance)
        {
            // We do not near-miss with ourselves
            if (t1 == t2)
            {
                return false;
            }
            // Get the positions of the tracks
            Position pos_t1 = t1.position;
            Position pos_t2 = t2.position;
            // Check if these points are within our test distance
            return is_closer_than(pos_t1, pos_t2, test_distance);
        }

        private bool is_near_miss(Track t1, Track t2)
        {
            return is_closer_than(t1, t2, near_miss_distance);
        }

        private bool is_mid_air(Track t1, Track t2)
        {
            return is_closer_than(t1, t2, mid_air_distance);
        }

        private bool is_at_destination(Track t1)
        {
            return is_closer_than(t1.position, t1.destination, at_distination_distance);
        }

        public List<ATC_Event> detect_events(List<Track> tracks)
        {
            // The list of events to be returned
            List<ATC_Event> events = new List<ATC_Event>();
            // We need to check conditions for each of our tracks
            foreach (Track t1 in tracks)
            {
                // Check for near misses
                // TODO: BSP to avoid O(n^2)
                foreach (Track t2 in tracks)
                {
                    if (is_mid_air(t1, t2))
                    {
                        events.Add(new ATC_Event(ATC_Event.EventType.MID_AIR, new Pair<Track, Track>(t1, t2)));
                    }
                    else if (is_near_miss(t1, t2))
                    {
                        events.Add(new ATC_Event(ATC_Event.EventType.NEAR_MISS, new Pair<Track, Track>(t1, t2)));
                    }
                }
                // Check for arrival at destination
                if (is_at_destination(t1))
                {
                    events.Add(new ATC_Event(ATC_Event.EventType.TRACK_AT_DESTINATION, new Pair<Track, Track>(t1, t1)));
                }
            }

            // return the list
            return events;
        }
    }
}
