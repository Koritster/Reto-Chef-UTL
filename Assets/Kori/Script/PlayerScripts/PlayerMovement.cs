using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        charController.Move(Move * SpeedMove * Time.deltaTime);
    }

    public void Detener()
    {
        charController.Move(Vector3.zero);
    }
}
