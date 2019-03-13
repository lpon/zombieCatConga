using UnityEngine;

public class CatController : MonoBehaviour
{
    public Collider2D collisionDetection;

    private Vector3 positionOfTarget;
    private Transform targetToFollow;
    private float forwardSpeed;
    private float rotationSpeed;
    private bool isZombie;


    private void Update()
    {
        if (isZombie)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetDirection = positionOfTarget - currentPosition;

            float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * 
                                Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(
                                    transform.rotation,
                                    Quaternion.Euler(0, 0, targetAngle),
                                    rotationSpeed * Time.deltaTime
                                    );

            float distanceToTarget = targetDirection.magnitude;
            if (distanceToTarget > 0)
            {
                if (distanceToTarget > forwardSpeed)
                {
                    // If the magnitude of the vector connecting this cat and 
                    // targetToFollow is greater than the forward speed, set the 
                    // distanceToTarget to the forward speed so that the cat 
                    // moves towards targetToFollow in increments of forwardSpeed 
                    // per frame
                    distanceToTarget = forwardSpeed;
                }

                targetDirection.Normalize();
                Vector3 targetPosition = targetDirection * distanceToTarget + currentPosition;
                transform.position = Vector3.Lerp(currentPosition, targetPosition, forwardSpeed * Time.deltaTime);
            }
        }
    }

    public void JoinConga(Transform targetToFollow, float forwardSpeed, float rotationSpeed)
    {
        this.targetToFollow = targetToFollow;
        this.positionOfTarget = targetToFollow.position;
        this.forwardSpeed = forwardSpeed * 2f;
        this.rotationSpeed = rotationSpeed;

        isZombie = true;

        collisionDetection.enabled = false;
        GetComponent<Animator>().SetBool("inConga", true);
    }

    void UpdateTargetPosition()
    {
        this.positionOfTarget = this.targetToFollow.position;
    }

    void DestroyCatGameObject()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        if (!isZombie)
        {
            Destroy(gameObject);
        }
    }
}
