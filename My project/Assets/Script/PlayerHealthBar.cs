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
        PlayerHealth.HealthChanged += setUi;
    }



    public void setUi(float amount)
    {
        Debug.Log(amount);
        bar.value = amount / PlayerStat.instance.maxHealth;

    }
}
