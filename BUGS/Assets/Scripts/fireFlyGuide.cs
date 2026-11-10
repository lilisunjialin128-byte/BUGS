using System.Collections.Generic;
using UnityEngine;

public class FireflyGuide : MonoBehaviour
{
    public List<GameObject> fireflies;

    void Start()
    {
        foreach (var f in fireflies) f.SetActive(false);
        if (fireflies.Count > 0) fireflies[0].SetActive(true);
    }

    void Update()
    {
        if (fireflies.Count == 0 || !fireflies[0].GetComponent<FireflyFade>().Done) return;

        fireflies.RemoveAt(0);
        if (fireflies.Count > 0) fireflies[0].SetActive(true);
    }
}