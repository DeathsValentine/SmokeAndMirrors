using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    public Transform player;
    //public GameObject player1;
    //public GameObject player2;
    Animator animator;

    public Transform attackPoint;
    public LayerMask playerLayer;
    public float atkRange = 100f;

    private float lastAttacked = 0f;
    private Rigidbody rb;
    private Vector3 movement;
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
        rb=this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
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
    }

    void FixedUpdate()
    {
        player=GameObject.FindWithTag("Player").transform;
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);
        //bool isRunning = animator.GetBool("wolfRun");
        if (distanceFromPlayer <= 20) 
        {
            moveEnemy(player.position.x, player.position.z);
        }
      
    }
    public void moveEnemy(float playerX, float playerY)
    {
        Vector3 direction = (new Vector3 (playerX , 0 , playerY))-transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        rb.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));
        direction.Normalize();
        var distance = Vector3.Distance(new Vector3 (playerX , 0 , playerY), transform.position);
        if (distance > 2f)
        {
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
        else if(lastAttacked + 2f <= Time.time){
            lastAttacked = Time.time;
            Attack();
        }
        transform.LookAt(player);
    }

    public void Attack()
    {
        bool alreadyHit = false;
        if (gameObject.tag == "Bandit")
        {
            bool isRunning = animator.GetBool("attack");
            animator.SetBool("attack", true);
            Invoke("SetAnimationFalse", 0.5f);
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, atkRange, playerLayer);
            foreach (Collider player in hitPlayer)
            {
                Debug.Log("hits someone called " + player.gameObject.name);
                if (player.gameObject.name == "Priestess_model" && alreadyHit == false)
                {
                    alreadyHit = true;
                    player.GetComponentInParent<MerlynAction>().Damage(10);
                }
                if (player.gameObject.name == "Priestess_model" && alreadyHit == false)
                {

                    alreadyHit = true;
                    player.GetComponent<ScarlettAction>().Damage(10);
                }
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
            float  damage = otherScript.getDamage();
            health -= damage;
            if (health < 0) health = 0;
            Debug.Log("took " + damage + " damage, Health is now at " + health);
        }

/*        if(other.collider.tag == "Player")
        {
            if (other.collider.name == player.gameObject.name)
            {
                Debug.Log("ok");
            }
        }*/
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "Freeze" && lastHitByFreeze + 2f <= Time.time)
        {
            lastHitByFreeze = Time.time;
            /*FreezeDamage otherScript = other.transform.GetComponent<FreezeDamage>();
            Debug.Log(otherScript);
            float damage = otherScript.getDamage();*/
            float damage = Player.Intelligence * 20 * Random.Range(0.95f,1.05f);
            health -= damage;
            if (health < 0) health = 0;
            Debug.Log("took " + damage + " damage, Health is now at " + health);
        }
    }
    void SetAnimationFalse()
    {
        if (animator.GetBool("attack")) animator.SetBool("attack", false);
    }
}
