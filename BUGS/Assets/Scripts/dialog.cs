using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text;
    public playerMovement player;
    public float range = 3f;
    [TextArea] public string[] lines;
    private int index;

    void Start() => panel.SetActive(false);

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        if (panel.activeSelf)
        {
            if (++index < lines.Length) text.text = lines[index];
            else Show(false);
            return;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 100f) && hit.transform.IsChildOf(transform)
            && Vector3.Distance(player.transform.position, transform.position) <= range)
            Show(true);
    }

    void Show(bool on)
    {
        panel.SetActive(on);
        player.enabled = !on;
        if (on) text.text = lines[index = 0];
    }
}