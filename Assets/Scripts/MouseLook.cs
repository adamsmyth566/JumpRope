using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 acceleration;
    [Tooltip("A multiplier to the input. Describes the maxium speed in degrees / second. to flip rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private float inputLagPeriod;


    private Vector2 velocity;
    private Vector2 rotation; // The current rotation, in degrees
    private Vector2 lastInputEvent;
    private float inputLagTimer; 

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

        Debug.Log(wantedVelocity);

        velocity = new Vector2
          (
           Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
           Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
          );

        rotation += wantedVelocity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0); 
    }
}
