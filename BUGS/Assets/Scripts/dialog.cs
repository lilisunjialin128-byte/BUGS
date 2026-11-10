using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject panel, crosshair, dialogCam;
    public inputManager player;
    public TMP_Text text;
    public float range = 5f;
    [TextArea] public string[] lines;
    private int index;

    void Start() => Show(false);

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (panel.activeSelf)
        {
            if (++index < lines.Length) text.text = lines[index];
            else Show(false);
            return;
        }

        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out var hit, 100f) && hit.transform.IsChildOf(transform)
            && Vector3.Distance(player.transform.position, transform.position) <= range)
            Show(true);
    }

    void Show(bool on)
    {
        panel.SetActive(on);
        crosshair.SetActive(!on);
        CameraManager.I.Switch(on ? dialogCam : null);
        player.enabled = !on;
        if (on) text.text = lines[index = 0];
    }
}