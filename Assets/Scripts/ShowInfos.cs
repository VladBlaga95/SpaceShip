using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowInfos : MonoBehaviour {

    // Use this for initialization
    public Text dmg;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dmg.text = "Projectile Damage:" + ProjectileStats.damage + "\n" +
                    "Number of enemies remaining:" + EnemySpawner.nuberOfEnemies;
                    

    }
}
