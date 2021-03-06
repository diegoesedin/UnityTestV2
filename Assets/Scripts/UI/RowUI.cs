using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyTest.UI
{
    /// <summary>
    /// UI class for Row creation.
    /// It receives data and handle it to create fields
    /// </summary>
    public class RowUI : MonoBehaviour
    {
        #region Inspector Fields

        /* Prefabs for each field type */
        [Header("Prefabs")]
        [SerializeField] private GameObject headFieldPrefab;
        [SerializeField] private GameObject dataFieldPrefab;

        #endregion

        #region Row Creation

        public void CreateHeader(string[] columns)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                NewField(headFieldPrefab, columns[i]);
            }
        }

        public void CreateDataRow(string[] columns, Dictionary<string, string> data)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (data.TryGetValue(columns[i], out string fieldText))
                    NewField(dataFieldPrefab, fieldText);
            }
        }

        /// <summary>
        /// Instantiates GameObject for a field and sets its text
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="text"></param>
        private void NewField(GameObject prefab, string text)
        {
            GameObject field = Instantiate(prefab, Vector3.zero, Quaternion.identity, this.transform);
            field.GetComponent<TextMeshProUGUI>().text = text;
        }

        #endregion
    }
}