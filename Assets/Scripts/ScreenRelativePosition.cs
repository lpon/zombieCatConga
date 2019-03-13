using UnityEngine;

public class ScreenRelativePosition : MonoBehaviour
{
    public enum ScreenEdge { LEFT, RIGHT, TOP, BOTTOM };
    public ScreenEdge screenEdge;
    public float yOffset;
    public float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = transform.position;
        Camera mainCamera = Camera.main;

        switch(screenEdge)
        {
            case ScreenEdge.RIGHT:
                newPosition.x = (mainCamera.aspect * mainCamera.orthographicSize) + 
                                xOffset;
                newPosition.y = yOffset;
                break;

            case ScreenEdge.LEFT:
                newPosition.x = -(mainCamera.aspect * mainCamera.orthographicSize) +
                                xOffset;
                newPosition.y = yOffset;
                break;

            case ScreenEdge.TOP:
                newPosition.x = xOffset;
                newPosition.y = mainCamera.orthographicSize + yOffset;
                break;

            case ScreenEdge.BOTTOM:
                newPosition.x = xOffset;
                newPosition.y = -mainCamera.orthographicSize + yOffset;
                break;
        }

        transform.position = newPosition;
    }

}
