namespace ATC
{
    namespace Utility
    {
        // ReSharper disable once InconsistentNaming
        // I'm good with this
        public class Pair<T, U>
        {
            public Pair(T first, U second)
            {
                this.first = first;
                this.second = second;
            }

            public T first { get; set; }
            public U second { get; set; }
        };
    }
}