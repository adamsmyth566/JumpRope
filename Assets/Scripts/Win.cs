using Unity.VisualScripting;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject player;
    public Light greenlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        greenlight.color = Color.green;
        greenlight.intensity = 0.75f;
        winCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(player);
    }
}
