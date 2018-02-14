using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour {

    public static float damage=25;
    public static float enemyDamage=25;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {       if(collision.gameObject.tag=="Enemy" || collision.gameObject.tag=="Player")
            DestroyObject(this.gameObject); 
    }
}
