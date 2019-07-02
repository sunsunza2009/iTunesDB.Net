using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Events;

namespace iTunesDB.Net.Readers
{
    public class MhlaReader : iTunesReader
    {
        public override string ObjectID => "mhla";
        public override string[] ChildIDs => new[] {"mhia"};
        public override Type DatabaseType => typeof(MhlaObject);
    }
}
