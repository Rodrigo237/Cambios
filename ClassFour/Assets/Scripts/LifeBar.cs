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
  //  private float startTime;
    private float lifeEnemy;
    
    void Start()
    {
        lifeBarImage.color = fullLife;
        lifeBarImage.fillAmount = 1;
    }

    public void SetHealth(float health) {

        this.lifeEnemy = health;
    }


    public void UpdateHealth(float currentHealth) {
        this.lifeBarImage.fillAmount = Mathf.Lerp(1,0,(currentHealth / this.lifeEnemy)/animDuration);
        this.lifeBarImage.color = Color.Lerp(fullLife, emptyLife, currentHealth / this.lifeEnemy);
    }

    // Update is called once per frame
  //  void Update()
    //{
        
      //  lifeBarImage.fillAmount = Mathf.Lerp(1, 0, (lifeEnemy- damage)/animDuration); //Interpolar la duracion y el tiempo de la animacion
       // lifeBarImage.color = Color.Lerp(fullLife, emptyLife, (lifeEnemy - damage) / animDuration);

   // }
    
}
