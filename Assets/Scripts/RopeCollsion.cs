using UnityEngine;
using System.Collections;

public class RopeCollsion : MonoBehaviour
{
    private bool isDead;

    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("rope collison : " + other.transform.name);

        if (other.gameObject.tag == "Rope")
        {
            Debug.Log("Rope Hit");
            // Destroy(this.gameObject);
            StartCoroutine(WaitAndDie());
        }
    }

    IEnumerator WaitAndDie ()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Player DEAD");
        //Destroy(this.gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameManager.gameOver();
    }

}

