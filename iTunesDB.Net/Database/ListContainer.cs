using System.Collections.Generic;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Database
{
    public class ListContainer : List<DbList>, IDbObject
    {
        public int TotalSize { get; set; }
        public ListTypes ListType { get; set; }
    }
}
