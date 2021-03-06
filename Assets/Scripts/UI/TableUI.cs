using System.Collections;
using System.Collections.Generic;
using MyTest.Data.DataReader;
using MyTest.Data.Entities;
using TMPro;
using UnityEngine;

namespace MyTest.UI
{
    /// <summary>
    /// UI class for Table creation.
    /// It gets Data and with that creates a header and completes the table.
    /// </summary>
    public class TableUI : MonoBehaviour
    {
        #region Private Fields
        /* Reference for object which retrieves data  */
        private DataReader _dataReader;

        #endregion

        #region Inspector Fields

        /* Text UI for Title */
        [Header("Main view")]
        [SerializeField] private TextMeshProUGUI titleText;

        /* Prefab for rows */
        [Header("Prefabs")]
        [SerializeField] private GameObject rowPrefab;

        #endregion


        void Awake()
        {
            //Here I only creates my implementation for the test, but I could change for another, for example @ApiDataReader
            _dataReader = new JsonDataReader();
        }

        void Start()
        {
            LoadData();
        }

        #region Table Generation

        /// <summary>
        /// Reads the data and init table initialization
        /// </summary>
        private async void LoadData()
        {
            Members data = await _dataReader.GetMembers();

            titleText.text = data.Title;

            CreateTable(data);
        }

        private void CreateTable(Members members)
        {
            SetData(members.ColumnHeaders, members.Data);
        }

        private void CreateHeader(string[] columns)
        {
            CreateRow().CreateHeader(columns);
        }

        private void SetData(string[] columns, Dictionary<string, string>[] columnDataArray)
        {
            CreateHeader(columns);

            for (int i = 0; i < columnDataArray.Length; i++)
            {
                CreateRow().CreateDataRow(columns, columnDataArray[i]);
            }
        }

        /// <summary>
        /// Instantiates GameObject for a row and return Row UI class
        /// </summary>
        /// <returns></returns>
        private RowUI CreateRow()
        {
            GameObject row = Instantiate(rowPrefab, Vector3.zero, Quaternion.identity, this.transform);
            return row.GetComponent<RowUI>();
        }

        #endregion
    }
}