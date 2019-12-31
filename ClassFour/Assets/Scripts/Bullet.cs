using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject decalPrefab;
    private GameObject decaltemp;

     void OnCollisionEnter(Collision collision)
    {
        //  decaltmp.transform.parent = objectTransform; // se hace hijo para realizar el seguimiento
        ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = collision.contacts[0].point;
        Vector3 norm = collision.contacts[0].normal;
        decaltemp =Instantiate(decalPrefab, pos + (norm * 0.01f), Quaternion.identity);
        decaltemp.transform.forward = norm;
        decaltemp.transform.parent = collision.transform;
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().countlife -= 1;
        }
        Destroy(this.gameObject);
    }
}
