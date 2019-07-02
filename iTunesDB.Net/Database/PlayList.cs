using System.Collections.Generic;
using iTunesDB.Net.Attributes;

namespace iTunesDB.Net.Database
{
    public class PlayList : List<PlayListItem>, IDbObject
    {
        [DataObject("Title")]
        public string Name { get; set; }

        [DataObject("Unknown2")]
        public string Unknown2 { get; set; }
    }
}
