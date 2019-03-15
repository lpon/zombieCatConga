using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatUpdater : MonoBehaviour
{
    private CatController catController;

    // Start is called before the first frame update
    void Start()
    {
        catController = transform.parent.GetComponent<CatController>();
    }

    // Update is called once per frame
    void UpdateTargetPosition()
    {
        catController.UpdateTargetPosition();
    }

    private void OnBecameInvisible()
    {
        catController.OnBecameInvisible();
    }

    private void DestroyCatGameObject()
    {
        catController.DestroyCatGameObject();
    }
}
