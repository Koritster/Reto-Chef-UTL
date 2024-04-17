using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float xMove;
    private float yMove;
    private float xRotation;
    [SerializeField] private Transform playerBody;
    public Vector2 lockAxis;
    public float sens;

    // Start is called before the first frame update
    void Start()
    {
        sens = PlayerPrefs.GetFloat("sens", 10);
    }

    // Update is called once per frame
    void Update()
    {
        xMove = lockAxis.x * sens * Time.deltaTime;
        yMove = lockAxis.y * sens * Time.deltaTime;
        
        xRotation -= yMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * xMove);
    }
}
