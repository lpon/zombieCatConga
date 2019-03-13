using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float forwardSpeed;
    public float rotationSpeed;
    
    private Vector3 targetDirection;
    private List<Transform> congaLine = new List<Transform>();

    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    private void Start()
    {
        targetDirection = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetButton("Fire1"))
        {
            // With orthographic projection, the z position of the mouse has no effect
            // (we only care about the x and y position which is obtainable by passing
            // the mouse position directly)
            Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Find vector with direction towards the mouse position
            targetDirection = moveToward - currentPosition;
            targetDirection.z = 0;
            // Ensure that moveDirection has "unit length" because it will
            // make it easier when multiplying the direction vector by some magnitude
            targetDirection.Normalize();
        }

        Vector3 targetPosition = (targetDirection * forwardSpeed) + currentPosition;
        // Lerp normalizes data to 0-1 range so that the position changes 
        // in a linear fashion between currentPosition and target
        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime);

        // Rotate Zombie by calculating the angle between the current direction
        // and the moveDirection
        float targetAngleRad = Mathf.Atan2(targetDirection.y, targetDirection.x);
        float targetAngleDeg = targetAngleRad * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp(
                                            transform.rotation,
                                            Quaternion.Euler(0, 0, targetAngleDeg),
                                            rotationSpeed * Time.deltaTime
                                            );
        EnforceBounds();
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cat"))
        {
            Transform targetToFollow = congaLine.Count == 0 ? 
                                        transform : congaLine[congaLine.Count-1];

            collision.GetComponent<CatController>().JoinConga(targetToFollow, forwardSpeed, rotationSpeed); ;
            congaLine.Add(collision.transform);
        } 

        if (collision.CompareTag("enemy"))
        {
            Debug.Log("Pardon me, ma'am");
        }
    }

    private void EnforceBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 newPosition = transform.position;
        Vector3 cameraPosition = mainCamera.transform.position;

        // Camera position is at (0, 0) which is the center of the screen
        float halfWidth = mainCamera.aspect * mainCamera.orthographicSize - 0.5f;
        float xMax = cameraPosition.x + halfWidth;
        float xMin = cameraPosition.x - halfWidth;

        float halfHeight = mainCamera.orthographicSize - 0.5f;
        float yMax = cameraPosition.y + halfHeight;
        float yMin = cameraPosition.y - halfHeight;

        if (transform.position.x < xMin || transform.position.x > xMax)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            targetDirection.x = -targetDirection.x;
        }

        if (transform.position.y < yMin || transform.position.y > yMax)
        {
            newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
            targetDirection.y = -targetDirection.y;
        }

        transform.position = newPosition;

    }
}
