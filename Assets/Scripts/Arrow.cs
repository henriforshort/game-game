using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public Vector3 startPosition;
    public float speed;
    public float amplitude;

    public void Start () {
        startPosition = transform.position;
    }

    public void Update () {
        float offset = Mathf.Sin(Time.time * speed);
        transform.position = startPosition + offset * Vector3.right * amplitude;
    }
}