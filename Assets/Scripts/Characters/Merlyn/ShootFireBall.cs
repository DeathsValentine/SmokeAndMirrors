﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
