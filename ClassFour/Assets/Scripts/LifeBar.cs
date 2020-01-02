using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{

    public Image lifeBarImage;
    public Color fullLife;
    public Color emptyLife;
    public float animDuration;
    private float startTime;
    private float lifeEnemy;
    private float currentHealth;
    void Start()
    {
        lifeBarImage.color = fullLife;
        lifeBarImage.fillAmount = 1;
        startTime = Time.time;

        lifeEnemy = this.GetComponentInParent<EnemyController>().lifeEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = this.GetComponentInParent<EnemyController>().currentHealth;
        this.lifeBarImage.fillAmount = currentHealth / lifeEnemy;
        this.lifeBarImage.color = Color.Lerp(fullLife, emptyLife, currentHealth / lifeEnemy);

        //currentHealth = this.GetComponentInParent<EnemyController>().currentHealth;
        //  lifeBarImage.fillAmount = Mathf.Lerp(1, 0, (lifeEnemy- damage)/animDuration); //Interpolar la duracion y el tiempo de la animacion
        // lifeBarImage.color = Color.Lerp(fullLife, emptyLife, (lifeEnemy - damage) / animDuration);

    }
    
}
