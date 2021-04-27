using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBladeDance : MonoBehaviour
{
    private float lastUsed = 0f;
    public static UseBladeDance dummy;

    public Transform attackPoint;
    public float atkRange = 1f;
    public LayerMask enemyLayer;

    private BladeDance bladeDance;

    void Awake()
    {
        dummy = GetComponent<UseBladeDance>();
        bladeDance = new BladeDance(Player.Strength);
    }

    public bool BladeDance()
    {
        bool useSkill = false;
        if (lastUsed + 5f <= Time.time)
        {
            useSkill = true;
            StartCoroutine(Active());
            StartCoroutine(DOT());
            lastUsed = Time.time;
        }
        return useSkill;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability2").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(5);
        GameObject.Find("Ability2").GetComponent<Button>().interactable=true;
    }

    IEnumerator DOT()
    {
        for (int i = 0; i < 5; i++)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, atkRange, enemyLayer);
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().Damage(bladeDance.getDamage());
            }
            yield return new WaitForSeconds(1);
        }
    }
}
