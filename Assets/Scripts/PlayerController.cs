using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    // Use this for initialization
    Vector3 boundryLeft;
    Vector3 boundryRight;
    Vector3 boundryCenter;
    public float offsetX;
    bool isRight = true;

    void Start()
    {
       boundryLeft  = Camera.main.ViewportToWorldPoint(new Vector3(0,0));
       boundryRight = Camera.main.ViewportToWorldPoint(new Vector3(1,0));
       boundryCenter=new Vector3((boundryLeft.x + boundryRight.x) / 2,boundryLeft.y );
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            Movement();
        }
        else
        {
            EnemyMovement();
        }

    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movement = new Vector3(Mathf.Clamp(-movementSpeed*Time.deltaTime + transform.position.x,boundryLeft.x+offsetX,boundryRight.x-offsetX), transform.position.y, transform.position.z);
            transform.position = movement;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movement = new Vector3(Mathf.Clamp(movementSpeed*Time.deltaTime + transform.position.x,boundryLeft.x+offsetX,boundryRight.x-offsetX), transform.position.y, transform.position.z);
            transform.position = movement;
        }
    }
    void EnemyMovement()
    {
        if(isRight)
        {//Move left
            Vector3 movement = new Vector3(Mathf.Clamp(-movementSpeed * Time.deltaTime + transform.position.x, boundryLeft.x + offsetX, boundryRight.x - offsetX), transform.position.y - offsetX * Time.deltaTime, transform.position.z);
            transform.position = movement;
            //Debug.Log(transform.position.x + " " + (boundryLeft.x+offsetX));
            if (transform.position.x <= boundryLeft.x + offsetX)
                isRight = false;
        }
        if(!isRight)
        {
            Vector3 movement = new Vector3(Mathf.Clamp(+movementSpeed * Time.deltaTime + transform.position.x, boundryLeft.x + offsetX, boundryRight.x - offsetX), transform.position.y- offsetX*Time.deltaTime, transform.position.z);
            transform.position = movement;
           // Debug.Log(transform.position.x + " " + (boundryLeft.x + offsetX));
            if (transform.position.x>= boundryRight.x - offsetX)
                isRight = true;
        }
        Debug.Log(boundryCenter.y);
        if(boundryCenter.y+3f>=transform.position.y)
        {
            SceneManager.LoadScene(0);
        }
    }

}
