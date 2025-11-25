using UnityEngine;
using System.Collections;

public class RopeCollsion : MonoBehaviour
{
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("rope collison" + collision.transform.name);
    //    if (collision.gameObject.tag == "Rope")
    //        Debug.Log("Rope Hit");
    //    Destroy(this.gameObject);
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("rope collison : " + collision.transform.name);

    //    if (collision.gameObject.tag == "Rope")
    //    {
    //        Debug.Log("Rope Hit");
    //        Destroy(this.gameObject);
    //    }
    //}

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

        Debug.Log("Rope Hit");
        Destroy(this.gameObject);
    }

}

