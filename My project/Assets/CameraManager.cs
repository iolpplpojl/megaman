using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static CameraManager instance;
    public CinemachineCamera cam;
    public float size;
    void Start()
    {
        instance = this;
        cam = GetComponent<CinemachineCamera>();
    }
    void Update()
    {
        // 실제로 선형 보간
        cam.Lens.OrthographicSize = Mathf.Lerp(cam.Lens.OrthographicSize, size, Time.deltaTime / 0.5f);
    }
    public void SwitchCam(Transform trans, float Damp, float lens)
    {
        GetComponent<CinemachineFollow>().TrackerSettings.PositionDamping = new Vector3(Damp, Damp);
        size = lens;
        cam.Follow = trans;
    }
}
