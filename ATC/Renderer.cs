using System;
using System.Collections.Generic;

namespace ATC
{
    class Renderer
    {
        private void output(string str)
        {
            Console.WriteLine(str);
        }

        public void renderTracks(List<Track> tracks)
        {
            foreach (Track t in tracks)
            {
                output(t.ToString());
            }
        }
    }
}
