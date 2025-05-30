using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{

    public bool selected;
    public Image image;

    protected void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    protected void Update()
    {
        if (selected)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
