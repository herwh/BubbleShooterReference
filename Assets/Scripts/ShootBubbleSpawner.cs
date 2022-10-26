using System.Collections;
using Data;
using UnityEngine;

public class ShootBubbleSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Bubble _bubble;
    [SerializeField] private BubbleData _bubbleData;
    [SerializeField] private float _spawnDelay;

    public bool HasBubble => _currentBubble != null;
    private Bubble _currentBubble;

    public Bubble PopBubble()
    {
        var bubble = _currentBubble;
        _currentBubble = null;
        StartCoroutine(SpawnNewShootBubble());
        return bubble;
    }

    private void Start()
    {
        SpawnShootBubble();
    }

    private void SpawnShootBubble()
    {
        _currentBubble = Instantiate(_bubble, _spawnPosition.position, Quaternion.identity);
        _currentBubble.SetColor(_bubbleData.GetRandomColor());
    }

    private IEnumerator SpawnNewShootBubble()
    {
        yield return new WaitForSeconds(_spawnDelay);
        SpawnShootBubble();
    }
}