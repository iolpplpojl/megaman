using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealth ph;
    public Slider bar;
    void Start()
    {
        bar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.value = ph.health / PlayerStat.instance.maxHealth;
    }
}
