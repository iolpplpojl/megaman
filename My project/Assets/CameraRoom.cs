using UnityEngine;

public class CameraRoom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraManager.instance.SwitchCam(position, 3,5);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CameraManager.instance.SwitchCam(collision.transform,0.2f,3);
    }
}
