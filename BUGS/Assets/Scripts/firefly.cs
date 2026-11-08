using UnityEngine;

public class Firefly : MonoBehaviour
{
    private Vector3 start;

    void Start() => start = transform.position;
    void Update() => transform.position = start + new Vector3(Mathf.Sin(Time.time * 1.3f), Mathf.Sin(Time.time * 2f) * 0.5f, Mathf.Cos(Time.time * 1.1f)) * 0.5f;
}