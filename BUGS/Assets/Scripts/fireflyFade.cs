using System.Collections;
using System.Linq;
using UnityEngine;

public class FireflyFade : MonoBehaviour
{
    public float fadeIn = 2.5f, fadeOut = 1.5f;
    private Light lamp;
    private Material glow;
    private Collider trigger;
    private CharacterController player;
    private float intensity, alpha, k;

    public bool Done { get; private set; }

    void Awake()
    {
        lamp = GetComponentInChildren<Light>();
        var pr = GetComponentInChildren<ParticleSystemRenderer>();
        if (pr) glow = pr.material;
        intensity = lamp ? lamp.intensity : 0;
        alpha = glow ? glow.color.a : 0;
        trigger = GetComponentsInChildren<Collider>().FirstOrDefault(c => c.isTrigger);
        player = FindFirstObjectByType<CharacterController>();
    }

    void OnEnable() { k = 0; Set(); StartCoroutine(Fade(1)); }

    void Update()
    {
        if (k < 1 || Done || !trigger) return;
        var p = player.bounds.center;
        if (trigger.ClosestPoint(p) == p) Hide();
    }

    public void Hide()
    {
        if (Done) return;
        Done = true;
        StopAllCoroutines();
        StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float to)
    {
        float from = k;
        for (float t = 0; t < 1; t += Time.deltaTime / (to == 1 ? fadeIn : fadeOut))
        {
            k = Mathf.Lerp(from, to, t);
            Set();
            yield return null;
        }
        k = to; Set();
        if (to == 0) Destroy(gameObject);
    }

    void Set()
    {
        if (lamp) lamp.intensity = intensity * k;
        if (glow) { var c = glow.color; c.a = alpha * k; glow.color = c; }
    }

    void OnDestroy() { if (glow) Destroy(glow); }
}