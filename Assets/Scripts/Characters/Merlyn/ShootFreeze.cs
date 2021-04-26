using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootFreeze : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    GameObject freezePrefab;

    private float lastShot = 0f;
    private Freeze freeze;
    public static ShootFreeze dummy;


    // Start is called before the first frame update
    void Awake()
    {
        dummy = GetComponent<ShootFreeze>();
        freeze = new Freeze();
    }

    // Update is called once per frame
    public bool Shoot()
    {
        if (lastShot + 1f <= Time.time)
        {
            Debug.Log("Freeze Attack!");
            lastShot = Time.time;
            StartCoroutine(Active());
            GameObject particles = Instantiate(freezePrefab, shootPoint.position, shootPoint.rotation);
            Destroy(particles, 2f);
            return true;
        }
        return false;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability2").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability2").GetComponent<Button>().interactable=true;
    }
}