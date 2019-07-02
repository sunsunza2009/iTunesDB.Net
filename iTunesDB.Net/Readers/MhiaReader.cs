using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Events;

namespace iTunesDB.Net.Readers
{
    public class MhiaReader : iTunesReader
    {
        public override string ObjectID => "mhia";
        public override string[] ChildIDs => new[] {"mhod"};
        public override Type DatabaseType => typeof(MhiaObject);
    }
}
