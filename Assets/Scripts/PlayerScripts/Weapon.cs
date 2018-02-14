using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour {

    
    public float offsetY;
    public float growValue;
    public float maxGrow;

    bool isReleased = false;

    private GameObject fire;
    public GameObject projectile;

    private Color orange;

    public Slider charge;
    // Use this for initialization
    void Start () {

        charge.maxValue = maxGrow;
        orange = charge.GetComponentsInChildren<Image>()[1].color;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ProjectileStats.damage = 25f;
            if (isReleased == false)
            {
                fire = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + offsetY), Quaternion.identity);
                isReleased = true;
                
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (fire.transform.localScale.x <= maxGrow)
            {
                fire.transform.localScale = new Vector3(fire.transform.localScale.x + growValue * Time.fixedDeltaTime, fire.transform.localScale.y + growValue * Time.fixedDeltaTime);
                charge.value = fire.transform.localScale.x;
                ProjectileStats.damage = ProjectileStats.damage + 1.45f;
                Debug.Log(ProjectileStats.damage);
            }
            if(charge.value==maxGrow)
            {
                charge.GetComponentsInChildren<Image>()[1].color = Color.cyan;
            }            
            fire.transform.parent = this.gameObject.transform;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            fire.transform.parent = null;
            fire.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 5f);
            charge.value = 0;
            charge.GetComponentsInChildren<Image>()[1].color = orange;
            isReleased = false;
            
        }
    }
}
