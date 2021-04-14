using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject fireballPrefab;

    private float lastShot = 0f;
    private FireBall fireball;
    public static ShootFireBall dummy;


    // Start is called before the first frame update
    void Awake()
    {
        dummy = GetComponent<ShootFireBall>();
        fireball = new FireBall();
    }

    // Update is called once per frame
    public void Shoot()
    {
        if (lastShot + 1f <= Time.time)
        {
            Debug.Log("Fireball shot");
            lastShot = Time.time;
            Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
