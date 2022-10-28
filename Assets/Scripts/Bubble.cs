using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public int Row { get; set; }
    public int Column { get; set; }

    public Color Color
    {
        get => _spriteRenderer.color;
        set => _spriteRenderer.color = value;
    }

    public Vector3 Direction { get; set; }
    public event Action<Bubble, int, int, Color> OnCollision;

    private bool _isMoving;
    private float _throwForce;

    public Vector3 GetSize()
    {
        return _spriteRenderer.bounds.size * ScreenSize.GetScreenCorrelation();
    }

    public void MoveOnDirection(Vector3 direction, float throwForce)
    {
        _isMoving = true;
        Direction = direction;
        _throwForce = throwForce;
    }

    private void Start()
    {
        transform.localScale *= ScreenSize.GetScreenCorrelation();
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position += _throwForce * Direction * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.layer == 7)
        {
            _isMoving = false;
            var (row, column) = GridHelper.GetBubbleIndex(transform.position, GetSize());
            transform.position = GridHelper.GetCorrectBubblePosition(row, column, GetSize());

            OnCollision?.Invoke(this, row, column, _spriteRenderer.color);
            OnCollision = null;
        }
    }
}