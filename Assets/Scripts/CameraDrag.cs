using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 0.5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Vector3 dragOrigin;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    dragOrigin = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 0);
                    Vector3 dragOrigin3D = new Vector3(dragOrigin.x, dragOrigin.y, 0);

                    Vector3 touchDelta = touchPosition - dragOrigin3D;

                    Vector3 move = new Vector3(-touchDelta.x, -touchDelta.y, 0) * dragSpeed * Time.deltaTime;

                    transform.Translate(move, Space.World);

                    Vector3 clampedPosition = transform.position;
                    clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
                    clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
                    transform.position = clampedPosition;

                    dragOrigin = touch.position;
                    break;
            }
        }
    }
}
