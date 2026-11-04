using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager I;
    public GameObject[] cams;
    public float blendTime = 0.5f;

    void Awake()
    {
        I = this;
        Camera.main.GetComponent<CinemachineBrain>().DefaultBlend.Time = blendTime;
        Switch(null);
    }

    public void Switch(GameObject cam) { foreach (var c in cams) c.SetActive(c == cam); }
}