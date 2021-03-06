using System.Threading.Tasks;
using MyTest.Data.Entities;

namespace MyTest.Data.DataReader
{
    /// <summary>
    /// Demo class
    /// I have a data reader, for this test I only read data from a local json,
    /// but if in the future I have an API where I could read data,
    /// I will write code here for that implementation, and the rest of the code its the same.
    /// </summary>
    public class ApiDataReader : DataReader
    {
        public override Task<Members> GetMembers()
        {
            throw new System.NotImplementedException();
        }
    }
}