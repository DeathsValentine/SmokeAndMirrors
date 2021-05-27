using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class ShootFireBall : NetworkBehaviour
{
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject fireballPrefab;

    private float lastShot = 0f;
    public static ShootFireBall dummy;


    void Awake()
    {
        dummy = GetComponent<ShootFireBall>();
    }

    [Command]
    public void cmdShoot()
    {
        if (lastShot + 1f <= Time.time)
        {
            lastShot = Time.time;
            StartCoroutine(Active());
            Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
            NetworkServer.Spawn(fireballPrefab);
        }

    }
    public bool Shoot()
    {
        if (lastShot +1f  <= Time.time)
        {
            lastShot = Time.time;
            StartCoroutine(Active());
            Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
            return true;
        }

        return false;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability1").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability1").GetComponent<Button>().interactable=true;
    }

}
