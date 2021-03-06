
using System.IO;
using System.Threading.Tasks;
using MyTest.Data.Entities;
using Newtonsoft.Json;
using UnityEngine;

namespace MyTest.Data.DataReader
{
    /// <summary>
    /// Implementation for data reading from a local JSON
    /// I have defined the json path, so here I read that file and then return deserialized data
    /// </summary>
    public class JsonDataReader : DataReader
    {
        private readonly string _jsonPath = Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json");

        public override async Task<Members> GetMembers()
        {
            string json = await ReadLocalJson();
            Debug.Log($"<color=green>Read JSON:</color> {json}");

            Members membersResponse = JsonConvert.DeserializeObject<Members>(json);

            return membersResponse;
        }

        private async Task<string> ReadLocalJson()
        {
            if (File.Exists(_jsonPath))
            {
                return File.ReadAllText(_jsonPath);
            }
            else
                Debug.LogError($"JSON NOT FOUND: {_jsonPath}");

            return "{}";
        }
    }
}
