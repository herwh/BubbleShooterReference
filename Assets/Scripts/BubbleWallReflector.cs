using UnityEngine;

public class BubbleWallReflector : MonoBehaviour
{
    private Bubble _bubble;

    public void SetBubble(Bubble bubble)
    {
        _bubble = bubble;
    }

    private void Update()
    {
        ControlObjectPosition();
    }

    private void ControlObjectPosition()
    {
        var size = _bubble.GetSize() * 0.5f;
        var position = _bubble.transform.position;

        if (position.x < ScreenSize.MinPosition.x + size.x)
        {
            _bubble.Direction = GetReflectedDirection(Vector3.right);
            position.x = ScreenSize.MaxPosition.x - size.x;
        }

        if (position.y < ScreenSize.MinPosition.y)
        {
            Destroy(_bubble.gameObject);
        }

        if (position.x > ScreenSize.MaxPosition.x - size.x)
        {
            _bubble.Direction = GetReflectedDirection(Vector3.left);
            position.x = ScreenSize.MinPosition.x + size.x;
        }

        if (position.y > ScreenSize.MaxPosition.y - size.y)
        {
            _bubble.Direction = GetReflectedDirection(Vector3.down);
            position.y = ScreenSize.MinPosition.y + size.y;
        }
    }

    private Vector3 GetReflectedDirection(Vector3 normal)
    {
        var direction = _bubble.Direction;
        var reflectDirection = Vector3.Reflect(direction, normal);

        return reflectDirection;
    }
}