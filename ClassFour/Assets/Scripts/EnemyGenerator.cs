using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnRange;
    public Vector3[] spawnPoints = {new Vector3(20,0,10),new Vector3(16,0,9),new Vector3(-30,0,-3),new Vector3(-35,0,-6),new Vector3(-23,0,9),new Vector3(-15,0,-3) }; //Cambiar por posiciones exactas
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0f, 5f);
    }

    void spawnEnemy() {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0,spawnPoints.Length)], Quaternion.identity); 
        Debug.Log("Position"+ enemyPrefab.transform.position);
    }
}
