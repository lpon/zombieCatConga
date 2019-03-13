using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Transform cameraTransform;
    private float spriteWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + spriteWidth < cameraTransform.position.x)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += 2.0f * spriteWidth;
            transform.position = newPosition;
        }
    }
}
