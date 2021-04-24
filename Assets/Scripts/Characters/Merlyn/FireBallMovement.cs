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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        Debug.Log("fireball at position " + transform.position);
    }

    void OnCollisionEnter(Collision other)
    {
        /*ContactPoint contact = other.contacts[0];
        Vector3 collidePoint = contact.point;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);*/

        //GameObject particle = Instantiate(hitPrefab, collidePoint, rotation);
        //particle is destroyed after 0.5 seconds
        ///Destroy(particle, 0.5f);
        Destroy(this.gameObject);
    }
}
