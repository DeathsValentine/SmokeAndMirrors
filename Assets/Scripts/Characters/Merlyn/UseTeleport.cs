using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportFX;

    private float lastUsed = 0f;
    public static UseTeleport dummy;
    Vector3 target;

    void Awake()
    {
        dummy = GetComponent<UseTeleport>();
    }

    public void Tele()
    {
        Vector3 currentPos = transform.position;
        if (lastUsed + 1f <= Time.time)
        {
            lastUsed = Time.time;
            StartCoroutine(Active());
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                target = hit.point;
                target.y = 1f;
                transform.position = target;
                Debug.DrawRay(ray.origin, ray.origin + ray.direction * 100, Color.yellow, 1);
            }
            GameObject start = Instantiate(teleportFX, currentPos, transform.rotation);
            GameObject end = Instantiate(teleportFX, target, transform.rotation);

            Destroy(start, 2.0f);
            Destroy(end, 2.0f);
        }
    }

    IEnumerator Active()
    {
        GameObject.Find("Ability3").GetComponent<Button>().interactable=false;
        yield return new WaitForSeconds(1);
        GameObject.Find("Ability3").GetComponent<Button>().interactable=true;
    }
}
