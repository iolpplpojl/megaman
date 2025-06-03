using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoiceSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public DialogueChoice Dia;
    TMP_Text text;
    public bool selected = false;
    public Image img;

    public void setUp(DialogueChoice dia)
    {
        Dia = dia;
        text = GetComponentInChildren<TMP_Text>();
        text.text = Dia.text;
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
