using UnityEngine;
using System.Collections;

public class Scrolling: MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeZ=1;

    private Vector2 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector2.down * newPosition;
    }
}