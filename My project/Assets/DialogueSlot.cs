using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int idx;
    TMP_Text text;
    public bool selected = false;
    public Image img;

    public void setUp(string textz)
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = textz;
    }

    public void Update()
    {
        if (selected)
        {
            img.color = Color.red;
        }
        else
        {
            img.color = Color.white;
        }
    }
}
