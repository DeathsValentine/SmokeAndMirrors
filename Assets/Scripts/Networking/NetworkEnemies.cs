using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkEnemies : NetworkBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    //public Transform player;
    public GameObject [] playerList;
    public float[] distanceList;
    //public GameObject player2;
    Animator animator;
    private GameObject NM;
    public Transform attackPoint;
    public LayerMask playerLayer;
    public float atkRange = 100f;

    private float lastAttacked = 0f;
    private Rigidbody rb;
    private Vector3 movement;
    private float minVal = float.PositiveInfinity;
    private int index = -1;
    public float moveSpeed;
    public float health;

    private GameObject otherScript;
    private static GameManager gameManager;
    public float x;
    public float z;
    public float distanceFromPlayer;
    public float lastHitByFreeze = 0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        //NM = GameObject.FindGameObjectWithTag("NetworkManager");
    }
    

    // Update is called once per frame
    void Update()
    {
        /*player = GameObject.FindWithTag("Player").transform;
        //finds the angle between  where the enemy is currently facing and the player
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        direction.Normalize();
        movement = direction;*/

        //if health is 0 or less then set active to false and gold drop to true
        if (health <= 0)
        {
            gameManager.removeEnemy(gameObject);
        }
       // playerList = NM.GetComponent<NewNetworkManager>().getPList();
    }
    /*
    void FixedUpdate()
    {       
        for(int i = 0; i < playerList.Length; i++)
        {
            distanceList[i] = Vector3.Distance(transform.position, playerList[i].transform.position);
        }
        float minVal = float.PositiveInfinity;
        int index = -1;
        for(int i = 0; i < distanceList.Length; i++)
        {
            if (minVal > distanceList[i])
            {
                minVal = distanceList[i];
                index = i;
            }
        } 
        
        //bool isRunning = animator.GetBool("wolfRun");
        if (distanceList[index] <= 20)
        {
            if (gameObject.tag == "Dragon")
            {
                Attack();
            }
            moveEnemy(playerList[index].transform.position.x, playerList[index].transform.position.z);
        }

    }
    */
    public void moveEnemy(float playerX, float playerY)
    {
        Vector3 direction = (new Vector3(playerX, 0, playerY)) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        direction.Normalize();
        var distance = Vector3.Distance(new Vector3(playerX, 0, playerY), transform.position);
        if (distance > 2f && gameObject.tag != "Dragon")
        {
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
        else if (lastAttacked + 2f <= Time.time && gameObject.tag != "Dragon")
        {
            lastAttacked = Time.time;
            Attack();
        }
        transform.LookAt(playerList[index].transform);
    }

    public void Attack()
    {
        if (gameObject.tag == "Dragon")
        {
            bool shoots = DragonFire.dummy.Shoot();
            if (shoots)
            {
                animator.SetBool("fireball", true);
                Invoke("SetAnimationFalse", 0.5f);
            }
        }
    }
    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        Debug.Log("took " + damage + " damage, Health is now at " + health);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Fireball")
        {
            FireBallMovement otherScript = other.gameObject.GetComponent<FireBallMovement>();
            float damage = otherScript.getDamage();
            health -= damage;
            if (health < 0) health = 0;
            Debug.Log("took " + damage + " damage, Health is now at " + health);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "Freeze" && lastHitByFreeze + 2f <= Time.time)
        {
            lastHitByFreeze = Time.time;
            /*FreezeDamage otherScript = other.transform.GetComponent<FreezeDamage>();
            Debug.Log(otherScript);
            float damage = otherScript.getDamage();*/
            float damage = Player.Intelligence * 20 * Random.Range(0.95f, 1.05f);
            health -= damage;
            if (health < 0) health = 0;
            Debug.Log("took " + damage + " damage, Health is now at " + health);
        }
    }
    void SetAnimationFalse()
    {
        if (gameObject.tag == "Dragon")
        {
            if (animator.GetBool("fireball")) animator.SetBool("fireball", false);
        }
    }
}
