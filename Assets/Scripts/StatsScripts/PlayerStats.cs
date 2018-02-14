using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour {

    public float maxHp;
    public Slider hpSlider;
    private Color green;
    private float hp;
	void Start () {

        maxHp = 250;
        hp = maxHp;
        hpSlider.minValue = 0;
        hpSlider.maxValue = maxHp;
        green=hpSlider.GetComponentsInChildren<Image>()[1].color;

    }
	
	// Update is called once per frame
	void Update () {
        hpSlider.value = hp;
        hp =Mathf.Clamp(hp, 0, maxHp);
        if (hpSlider.value < maxHp/3)
        {
            hpSlider.GetComponentsInChildren<Image>()[1].color = Color.red;
        }
        else if (hpSlider.value < maxHp/2)
        {
            hpSlider.GetComponentsInChildren<Image>()[1].color = Color.yellow;
        }
        else
        {
            hpSlider.GetComponentsInChildren<Image>()[1].color = green;
        }
       if(hp<=0)
        {if(gameObject.tag=="Player")
                SceneManager.LoadScene(0);
        else
            Destroy(gameObject);
            EnemySpawner.nuberOfEnemies--;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyProjectiles")
        {
            hp = hp - ProjectileStats.enemyDamage;
        }
        else
            hp = hp - ProjectileStats.damage;   
    }
}
