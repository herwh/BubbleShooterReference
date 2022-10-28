using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New CustomGrid", menuName = "Custom Grid", order = 0)]
    public class CustomGridData : ScriptableObject
    {
        [SerializeField]private List<BubbleData> _bubbleDatas;

        public List<BubbleData> BubbleDatas => _bubbleDatas;
    }
}