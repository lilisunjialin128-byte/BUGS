using UnityEngine;

public class FireflyGuide : MonoBehaviour
{
    public Transform player;
    public GameObject[] fireflies;
    public float distance = 3f;
    private int index;

    void Start()
    {
        foreach (var f in fireflies) f.SetActive(false);
        fireflies[0].SetActive(true);
    }

    void Update()
    {
        if (index >= fireflies.Length) return;
        if (Vector3.Distance(player.position, fireflies[index].transform.position) > distance) return;

        fireflies[index].SetActive(false);
        if (++index < fireflies.Length) fireflies[index].SetActive(true);
    }
}