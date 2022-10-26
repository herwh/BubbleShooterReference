using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private bool _isMoving;
    private Vector3 _direction;
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
        _direction = direction;
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
            transform.position += _throwForce * _direction * Time.deltaTime;
        }
    }
}
