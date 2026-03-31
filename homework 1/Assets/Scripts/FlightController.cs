// FlightController.cs 
// CENG 454 – HW1: Sky-High Prototype 
// Author: Ýlhan Güven Erol | Student ID: 230446016

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;  // degrees/second pitch: up/down
    [SerializeField] private float yawSpeed = 45f;  // degrees/second yaw: left/right
    [SerializeField] private float rollSpeed = 45f;  // degrees/second roll: tilt left/right
    [SerializeField] private float thrustSpeed = 5f;   // units/second 
    private int toggleAccel;
    private float gravity = -9.81f;
    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    [SerializeField] private Rigidbody rb;

    //removed freezerotation as it will prevent physics based rotations which i prefer

    //i removed physics based rotations therefore freezerotaion is back
    void Awake()
    {
        rb.freezeRotation = true;
    }
    void Start()
    {
         toggleAccel = 0;
    }
    void Update()// or FixedUpdate() 
    {
        HandleRotation();
        HandleThrust();
        ToggleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): 
        // Pitch   
        // Roll    
        float roll = Input.GetAxis("Roll") * rollSpeed * Time.deltaTime; // roll left/right with Q/E
        float pitch = Input.GetAxis("Pitch") * pitchSpeed * Time.deltaTime; // pitch up/down with W/S
        float yaw = Input.GetAxis("Yaw") * yawSpeed * Time.deltaTime; // yaw left/right with A/D

        transform.Rotate(pitch, roll, -yaw, Space.Self);
    } 

    private void HandleThrust()
    {
        Vector3 counterGrav = transform.rotation.x*gravity*Time.deltaTime*transform.up*toggleAccel;
        Vector3 thrustVector = thrustSpeed * Time.deltaTime * toggleAccel * transform.forward;
        rb.MovePosition(rb.position + thrustVector + counterGrav);
        Debug.Log("Thrust: " + (toggleAccel * thrustSpeed));
    }

    private void ToggleThrust() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleAccel = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            toggleAccel = 0;
        }
    }
}