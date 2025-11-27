using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.RotateAround(target.position, Vector3.forward, 170 * Time.deltaTime); 

    }
}
