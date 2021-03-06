using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseDash : MonoBehaviour
{
    public Rigidbody rb;
    private float lastUsed = 0f;
    public static UseDash dummy;
    private float dashSpeed;
    Vector3 target;

    public Transform attackPoint;
    public float atkRange = 1f;
    public LayerMask enemyLayer;

    private Dash dash;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dummy = GetComponent<UseDash>();
        dashSpeed = 15;
        dash = new Dash(Player.Strength);
    }

    public bool Dash()
    {
        bool useSkill = false;
        Vector3 currentPos = transform.position;
        if (lastUsed + 1f <= Time.time)
        {
            useSkill = true;
            lastUsed = Time.time;
            StartCoroutine(Active());
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                target = hit.point - transform.position;
                target.y = 0f;
                rb.velocity = target * dashSpeed;
                Debug.DrawRay(ray.origin, ray.origin + ray.direction * 100, Color.yellow, 1);
            }
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, atkRange, enemyLayer);
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().Damage(dash.getDamage());
            }
        }
        return useSkill;
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability1").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability1").GetComponent<Button>().interactable=true;
    }
}
