using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonFire : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject fireballPrefab;

    private float lastShot = 0f;
    public static DragonFire dummy;


    void Awake()
    {
        dummy = GetComponent<DragonFire>();
    }

    public bool Shoot()
    {
        if (gameObject.tag == "Dragon" && lastShot + 0.5f <= Time.time)
        {
            lastShot = Time.time;
            Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
            return true;
        }
        return false;
    }
}
