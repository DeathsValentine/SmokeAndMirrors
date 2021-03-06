using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 firingPoint;
    
    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private GameObject explosionPrefab;
    private FireBall fireball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firingPoint = transform.position;
        fireball = new FireBall(Player.Intelligence);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "MerlynPrefab(Clone)")
            {
                other.gameObject.GetComponentInParent<MerlynAction>().Damage(10);
            }
            if (other.gameObject.name == "ScarlettPrefab(Clone)")
            {
                other.gameObject.GetComponentInParent<ScarlettAction>().Damage(10);
            }
        }
        Destroy(this.gameObject);
    }
    
    public float getDamage()
    {
        return fireball.getDamage();
    }
}
