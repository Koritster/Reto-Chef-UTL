using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToGrab : MonoBehaviour
{
    private Quaternion initialRotate;

    // Start is called before the first frame update
    void Start()
    {
        initialRotate = transform.rotation;
    }

    public void CorrectRotation()
    {
        transform.rotation = initialRotate;
    }
}
