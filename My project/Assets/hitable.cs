using UnityEngine;

public class hitable : MonoBehaviour
{
    public void hit(GameObject attacker, float Damage)
    {
        if (attacker.transform.gameObject == transform.parent.gameObject)
        {
            Debug.Log("����");
            return;
        }
        Debug.Log("�ƾ�!" + transform.name);
        GetComponentInParent<Health>().getDamage(Damage);
    }
}
