using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public Vector3 Direction { get; set; }

    private bool _isMoving;
    private float _throwForce;

    public Vector3 GetSize()
    {
        return _spriteRenderer.bounds.size * ScreenSize.GetScreenCorrelation();
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
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
        }
    }
}
