using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Color Data", menuName = "Colors", order = 0)]
    public class ColorsData : ScriptableObject
    {
        [SerializeField] private List<Color> _colors;

        public IReadOnlyList<Color> Colors => _colors;

        public Color GetRandomColor()
        {
            var randomIndex = Random.Range(0, _colors.Count);
            return _colors[randomIndex];
        }
    }
}