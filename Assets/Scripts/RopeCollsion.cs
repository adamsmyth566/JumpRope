using UnityEngine;
using System.Collections;

public class RopeCollsion : MonoBehaviour
{
    private bool isDead;

    public GameManager gameManager;
    public GameObject deathEffect;

    public AudioSource audioSource;
    public AudioClip playerFallNoise;
    public AudioSource audioSource2; 
    public AudioClip ropeThump; 

    public void Awake()
    {
        deathEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("rope collison : " + other.transform.name);

        if (other.gameObject.tag == "Rope")
        {
            audioSource2.PlayOneShot(ropeThump);

            Debug.Log("Rope Hit");


            StartCoroutine(WaitAndDie());
        }
        else if(other.gameObject.tag == "Death")
        {
            audioSource.PlayOneShot(playerFallNoise);
            deathEffect.SetActive(true);
            Debug.Log("Player DEAD");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameManager.gameOver();
            Destroy(this.gameObject);
        }
    }

    IEnumerator WaitAndDie ()
    {
        
        yield return new WaitForSeconds(1f);

        audioSource.PlayOneShot(playerFallNoise); 
        deathEffect.SetActive(true);
        Debug.Log("Player DEAD");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameManager.gameOver();
        Destroy(this.gameObject);
    }

}

