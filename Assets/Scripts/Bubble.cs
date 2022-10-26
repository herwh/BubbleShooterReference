using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public Vector3 GetSize()
    {
        
        return _spriteRenderer.bounds.size * ScreenSize.GetScreenCorrelation();
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    
    private void Start()
    {
        transform.localScale *= ScreenSize.GetScreenCorrelation();
    }
}
