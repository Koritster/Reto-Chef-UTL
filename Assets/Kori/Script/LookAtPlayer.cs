using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private bool bug;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(bug) 
        { 
            transform.LookAt(mainCamera.transform.position - new Vector3(0, 0, 180));
        }
        else
        {
            transform.LookAt(mainCamera.transform.position);
        }
    }
}
