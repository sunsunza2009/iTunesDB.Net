using System;

namespace iTunesDB.Net.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DataObjectAttribute : Attribute
    {
        public string Value { get; private set; }

        public DataObjectAttribute(string Value)
        {
            this.Value = Value;
        }
    }
}
