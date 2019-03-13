using UnityEngine;

public class CatController : MonoBehaviour
{
    void DestroyCatGameObject()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
