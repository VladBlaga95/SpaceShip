using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    private GameObject fire;
    public GameObject projectile;
    public float offsetY;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        EnemyFire(); 
	}
    void EnemyFire()
    {
        if (Random.Range(0, 60) == 4)
        {
            fire = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - offsetY), Quaternion.identity);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -3f);
        }
    }
}
