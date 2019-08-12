using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public Vector3 startPosition;
    public float speed;
    public float amplitude;

    public void Start () {
        startPosition = transform.localPosition;
    }

    public void Update () {
            float movement = Mathf.Sin((Time.time * speed));
            transform.localPosition = startPosition + movement * Vector3.right * amplitude;
    }
}