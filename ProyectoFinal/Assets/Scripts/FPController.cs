using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


//Buttons
//    Square = joystick button 0
//    X       = joystick button 1
//    Circle  = joystick button 2
//    Triangle= joystick button 3
//    L1      = joystick button 4
//    R1      = joystick button 5
//    L2      = joystick button 6


//    R2      = joystick button 7
//    Share	= joystick button 8
//    Options = joystick button 9
//    L3      = joystick button 10
//    R3      = joystick button 11
//    PS      = joystick button 12
//    PadPress= joystick button 13

//Axes:
//    LeftStickX      = X-Axis
//    LeftStickY = Y - Axis(Inverted ?)
//    RightStickX     = 3rd Axis
//    RightStickY     = 4th Axis(Inverted?)
//    L2              = 5th Axis(-1.0f to 1.0f range, unpressed is -1.0f)
//    R2              = 6th Axis(-1.0f to 1.0f range, unpressed is -1.0f)
//    DPadX           = 7th Axis
//    DPadY           = 8th Axis(Inverted?)


public class FPController : MonoBehaviour {

    public float speed = 5f;

    private Transform cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private readonly float mouseSensitivity = 300f;
    private float verticalLookRotation;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 movHor = transform.right * xMov;    // ( 1, 0, 0)
        Vector3 movVer = transform.forward * yMov;  // ( 0, 0, 1)
        Vector3 movUp = transform.up * zMov;        // ( 0, 1, 0)

        velocity = (movHor + movVer + movUp).normalized * speed;

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

       // transform.Rotate(Vector3.up * Input.acceleration.x * Time.deltaTime );
        //verticalLookRotation += Input.acceleration.y * Time.deltaTime ;

        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);

        cam.localEulerAngles = Vector3.left * verticalLookRotation;


    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

}
