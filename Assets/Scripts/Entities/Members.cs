using System.Collections.Generic;

namespace MyTest.Data.Entities
{
    /// <summary>
    /// Data structure for Members
    /// </summary>
    [System.Serializable]
    public class Members
    {
        public string Title;
        public string[] ColumnHeaders;
        public Dictionary<string, string>[] Data;
    }
}