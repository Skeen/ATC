using System.Collections.Generic;

namespace ATC
{
    // ReSharper disable once InconsistentNaming
    // Exercise requires this
    class ATC_System
    {
        private List<Track> tracks;
        private Renderer renderer;
        private Log log;
        private ATC_EventDetector event_detector;

        public ATC_System()
        {
            tracks = new List<Track>();
            renderer = new Renderer();
            log = new Log();
            event_detector = new ATC_EventDetector();
        }

        // Does this ATC currently handle any track
        public bool handles_tracks()
        {
            return tracks.Count != 0;
        }

        // recieve an incoming track
        public void handle_incoming_track(Track t)
        {
            // Set the direction to go through our region
            //Direction direction = t.direction.getOppositeDirection();
            // Get the current position
            Position position = new Position(t.position);
            // Set the new destination
            t.destination = Track.advance_position_by_direction(position, t.direction, 100);
            // Add the track to our list
            tracks.Add(t);
        }

        // forward the simulation by delta_time seconds.
        public void tick(double delta_time)
        {
            int int_milliseconds = (int) delta_time * 1000;
            foreach(Track t in tracks)
            {
                t.update(int_milliseconds);
            }

            List<ATC_Event> events = event_detector.detect_events(tracks);
            foreach (ATC_Event e in events)
            {
                Track t1 = e.tracks.first;
                Track t2 = e.tracks.second;
                switch (e.actual_event)
                {
                    case ATC_Event.EventType.MID_AIR:
                        log.w("MID_AIR:\t" + t1.tag + t1.position + " and " + t2.tag + t2.position);
                        break;
                    case ATC_Event.EventType.NEAR_MISS:
                        log.w("NEAR_MISS:\t" + t1.tag + t1.position + " and " + t2.tag + t2.position);
                        break;
                    case ATC_Event.EventType.TRACK_AT_DESTINATION:
                        log.i("TRACK_AT_DESTINATION:\t" + e.tracks.first.tag);
                        tracks.Remove(e.tracks.first);
                        break;
                }
            }
            renderer.renderTracks(tracks);
        }
    }
}
