using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum DriveType { RearWheelDrive, FrontWheelDrive, AllWheelDrive }
public class WheelDrive : MonoBehaviour
{
    public bool Lap = false;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] float maxAngle = 30f;
    public float maxTorque = 300f;
    [SerializeField] float brakeTorque = 30000f;
    [SerializeField] GameObject wheelShape;

    public Vector3 spawnPosition;
    private Quaternion spawnRotation;
    Rigidbody rb;

    [SerializeField] float criticalSpeed = 10f;
    [SerializeField] int stepBelow = 5;
    [SerializeField] int stepAbove = 1;

    [SerializeField] DriveType driveType;
    WheelCollider[] carWheels;
    public float handBrake, torque;
    public float angle;

    public InputActionAsset inputActions;
    InputActionMap gameplayActionMap;
    InputAction handBrakeInputAction;
    InputAction steeringInputAction;
    InputAction accelerationInputAction;

    void Awake()
    {
        ResetSpawnPosition();

        gameplayActionMap = inputActions.FindActionMap("Gameplay");

        handBrakeInputAction = gameplayActionMap.FindAction("HandBrake");
        steeringInputAction = gameplayActionMap.FindAction("SteeringAngle");
        accelerationInputAction = gameplayActionMap.FindAction("Acceleration");

        handBrakeInputAction.performed += GetHandBrakeInput;
        handBrakeInputAction.canceled += GetHandBrakeInput;

        steeringInputAction.performed += GetAngleInput;
        steeringInputAction.canceled += GetAngleInput;

        accelerationInputAction.performed += GetTorqueInput;
        accelerationInputAction.canceled += GetTorqueInput;
        
    }
    void GetHandBrakeInput(InputAction.CallbackContext context)
    {
        handBrake = context.ReadValue<float>() * brakeTorque;
    }
    void GetAngleInput(InputAction.CallbackContext context)
    {
        angle = context.ReadValue<float>() * maxAngle;
    }
    void GetTorqueInput(InputAction.CallbackContext context)
    {
        torque = context.ReadValue<float>() * maxTorque;
    }

    private void OnEnable()
    {
        handBrakeInputAction.Enable();
        steeringInputAction.Enable();
        accelerationInputAction.Enable();

    }
    private void OnDisable()
    {
        handBrakeInputAction.Disable();
        steeringInputAction.Disable();
        accelerationInputAction.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carWheels = GetComponentsInChildren<WheelCollider>();
        for (int i = 0; i < carWheels.Length; i++)
        {
            var wheel = carWheels[i];
            if(wheelShape != null)
            {
                var ws = Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        } 

    }
    void Update()
    {
        carWheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepBelow, stepAbove);

        foreach (WheelCollider wheel in carWheels)
        {
            if (wheel.transform.localPosition.z > 0)
            {
                wheel.steerAngle = angle;
            }

            if(wheel.transform.localPosition.z < 0)
            {
                wheel.brakeTorque = handBrake;
            }

            if(wheel.transform.localPosition.z < 0 && driveType != DriveType.FrontWheelDrive)
            {
                wheel.motorTorque = torque;
            }

            if(wheel.transform.localPosition.z > 0 && driveType != DriveType.RearWheelDrive)
            {
                wheel.motorTorque = torque;
            }

            //This code block is responsible for updating the graphics of the car wheels to match their physical positions and rotations in the game. 
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                Transform shapeTransform = wheel.transform.GetChild(0);

                if(wheel.name == "a0l" || wheel.name == "a1l" || wheel.name == "a2l")
                {
                    shapeTransform.rotation = q * Quaternion.Euler(0, 180, 0);
                    shapeTransform.position = p;
                }
                else
                {
                    shapeTransform.position = p;
                    shapeTransform.rotation = q;
                }
            }

            if (IsGrounded())
            {
                Debug.Log("is UpsideDown");
                Invoke("RespawnCar", 1f);
            }
        }
    }
    public void ResetSpawnPosition()
    {
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }
    private void RespawnCar()
    {
        Debug.Log("Respawn");
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
        torque = 0;

        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
