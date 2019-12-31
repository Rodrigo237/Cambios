using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGenerator : MonoBehaviour
{
    public float distance;
    Ray viewRay;
    RaycastHit viewHit;
    public Camera fpsCam;
    public GameObject Crosshair;
    public float range = 100f;
    public float damage = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            viewRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f,Screen.height*0.5f,0f));

            if (Physics.Raycast(viewRay, out viewHit, distance)) {
                if (viewHit.transform.tag == "Sphere") {
                    viewHit.transform.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 150f); //Impulso
                }
            }
        }

        Shoot();
    }

    void Shoot() {
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out viewHit, range))
        {
            EnemyController enemyController = viewHit.transform.GetComponent<EnemyController>();
            Crosshair.transform.forward = viewHit.transform.position;
            if (enemyController != null) {
                enemyController.Damage(damage);
            }

        }
    }
}
