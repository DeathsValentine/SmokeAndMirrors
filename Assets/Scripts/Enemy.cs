using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    public Transform player;
    //public GameObject player1;
    //public GameObject player2;

    private Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
    public int health;

    private static GameManager gameManager;
    public float x;
    public float z;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb=this.GetComponent<Rigidbody>();
        
    }
    /***
    // Update is called once per frame
    void Update()
    {
        player=GameObject.FindWithTag("Player").transform;
        //finds the angle between  where the enemy is currently facing and the player
        Vector3 direction =player.position-transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        rb.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));

        direction.Normalize();
        movement =direction;
 
        //if health is 0 or less then set active to false and gold drop to true
        if (health <= 0)
        {
            gameManager.EnemyKilled();
            gold.SetActive(true);
        }
        
    }
    ***/

    void FixedUpdate()
    {
        player=GameObject.FindWithTag("Player").transform;
        moveEnemy(player.position.x, player.position.z);
    }
    public void moveEnemy(float playerX, float playerY)
    {

        Vector3 direction = (new Vector3 (playerX , 0 , playerY))-transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        rb.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));
        direction.Normalize();

        var distance = Vector3.Distance(new Vector3 (playerX , 0 , playerY), transform.position);
        Debug.Log("distance is " + distance);
        if(distance > 3)
        {
            Debug.Log("runs here");
            rb.MovePosition(transform.position + direction *moveSpeed *Time.deltaTime);
        }
        else {
            /*EnemyShoot.shot.Shoot();*/
        }
        transform.LookAt(player);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag=="Bullet")
        {
           health-=25;
        }
    }
}
