using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
       newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition.x += Time.deltaTime * speed;
        transform.position = newPosition;
    }
}
