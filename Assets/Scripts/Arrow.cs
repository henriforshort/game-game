using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public Vector3 startPosition;
    public float speed;
    public float amplitude;
    public bool horizontal;
    public float offset;
    public bool isStopped;

    public void Start () {
        startPosition = transform.localPosition;
    }

    public void Update () {
        if (!isStopped) {
            float movement = Mathf.Sin((Time.time * speed) + offset);
            if (horizontal) transform.localPosition = startPosition + movement * Vector3.right * amplitude;
            else transform.GetChild(0).localPosition = movement * transform.right * amplitude;
        }
    }
}