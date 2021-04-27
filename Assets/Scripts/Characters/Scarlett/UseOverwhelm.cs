using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseOverwhelm : MonoBehaviour
{
    private float lastUsed = 0f;
    public static UseOverwhelm dummy;

    public Transform attackPoint;
    public float atkRange = 3f;
    public LayerMask enemyLayer;

    private Overwhelm overwhelm;

    void Awake()
    {
        dummy = GetComponent<UseOverwhelm>();
        overwhelm = new Overwhelm(Player.Strength);
    }

    public bool Overwhelm()
    {
        bool useSkill = false;
        if (lastUsed + 1f <= Time.time)
        {
            Debug.Log("overwhelm activates");
            useSkill = true;
            StartCoroutine(Active());
            lastUsed = Time.time;
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, atkRange, enemyLayer);
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().Damage(overwhelm.getDamage());
            }
        }
        return useSkill;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability3").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability3").GetComponent<Button>().interactable=true;
    }
}
