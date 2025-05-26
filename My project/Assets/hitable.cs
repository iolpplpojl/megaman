using UnityEngine;

public class hitable : MonoBehaviour
{
    public void hit(GameObject attacker, float Damage)
    {
        if (attacker.transform.gameObject == transform.parent.gameObject)
        {
            Debug.Log("본인");
            return;
        }
        Debug.Log("아야!" + transform.name);
        GetComponentInParent<Health>().getDamage(Damage);
    }
}
