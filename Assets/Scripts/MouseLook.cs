using System;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Flags]

    public enum RotationDirection
    {
        None,
        Horizontal = (1 << 0), 
        Vertical = (1 << 1)
    }

    [SerializeField] private RotationDirection rotationDirection;
    [SerializeField] private Vector2 acceleration;
    [Tooltip("A multiplier to the input. Describes the maxium speed in degrees / second. to flip rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private float maxVerticalAngleFromHorizon;
    [SerializeField] private float inputLagPeriod;
    


    private Vector2 velocity;
    private Vector2 rotation; // The current rotation, in degrees
    private Vector2 lastInputEvent;
    private float inputLagTimer;

    private void OnEnable()
    {
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        Vector3 euler = transform.localEulerAngles;

        if (euler.x >= 180)
        {
            euler.x -= 360;
        }

        euler.x = ClampVerticalAngle(euler.x);

        transform.localEulerAngles = euler;

        rotation = new Vector2(euler.y, euler.x);
    }

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime; 

        Vector2 input = new Vector2
            (
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
            );

        if((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }

        return lastInputEvent;
    }

    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        if ((rotationDirection & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0; 
        }
        if((rotationDirection & RotationDirection.Vertical) == 0)
        {
            wantedVelocity.y = 0;
        }

                

            

        Debug.Log(wantedVelocity);

        velocity = new Vector2
          (
           Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
           Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
          );
        
        rotation += velocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0); 
    }
}
