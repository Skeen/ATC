using ATC.Utility;

namespace ATC
{
    // ReSharper disable once InconsistentNaming
    // Required from the exercise
    class ATC_Event
    {
        public enum EventType
        {
            NEAR_MISS,
            MID_AIR,
            TRACK_AT_DESTINATION
        };

        public ATC_Event(EventType ev, Pair<Track, Track> tracks)
        {
            this.actual_event = ev;
            this.tracks = tracks;
        }

        public EventType actual_event { get; private set; }
        public Pair<Track, Track> tracks { get; private set; }
    }
}
