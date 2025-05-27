using UnityEngine;

public class EnemyDealer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float DealTime;
    float time;
    private void FixedUpdate()
    {
        if(time >= 0)
        {
            time -= Time.fixedDeltaTime;
        }
        else
        {

        }
    }


    public void Deal(GameObject target)
    {
        if (time <= 0)
        {
            Debug.Log(target + " ав╬Н╤С!");
            target.GetComponent<hitable>().hit(gameObject,50f);

            time = DealTime;
        }
    }
}
