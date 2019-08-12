using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {
    public bool moving;
    public Vector3 startLocalPos;
    public float speed;
    public float amplitude;
    public float offset;

    private void Start () {
        startLocalPos = transform.localPosition;
    }

    private void Update () {
        if (moving) {
            float variance = Mathf.Sin(speed * Time.time + offset);
            Vector3 movement = variance * Vector3.right * Time.deltaTime * amplitude;
            transform.localPosition = startLocalPos +  movement;
        } else transform.localPosition = Vector3.Lerp(transform.localPosition, startLocalPos, 0.2f);
    }
}