using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class BubbleData
    {
        [SerializeField] private int _rowIndex;
        [SerializeField] private int _columnIndex;
        [SerializeField] private int _colorIndex;

        public int RowIndex => _rowIndex;
        public int ColumnIndex => _columnIndex;
        public int ColorIndex => _colorIndex;
        
    }
}