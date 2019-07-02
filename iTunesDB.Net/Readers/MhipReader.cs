using System;
using iTunesDB.Net.Database;

namespace iTunesDB.Net.Readers
{
    internal class MhipReader : iTunesReader
    {
        public override string ObjectID => "mhip";
        public override string[] ChildIDs => new[] {"mhod"};
        public override Type DatabaseType => typeof(MhipObject);
    }
}
