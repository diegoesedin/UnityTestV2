using System.Threading.Tasks;
using MyTest.Data.Entities;

namespace MyTest.Data.DataReader
{
    /// <summary>
    /// Base abstract class to read data.
    /// This only to separate implementations in the future.
    /// </summary>
    public abstract class DataReader
    {
        public abstract Task<Members> GetMembers();
    }
}