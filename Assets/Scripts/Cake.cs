using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour {
    float rotateSpeed = 5f;
    public float translateSpeed = 1f;

    public float x, y, z;

    private void Update () {
        x = Mathf.Clamp(x + Random.Range(-1f, 1f), -20, 20);
        y = Mathf.Clamp(y + Random.Range(-1f, 1f), -20, 20);
        z = Mathf.Clamp(z + Random.Range(-1f, 1f), -20, 20);

        transform.Rotate(new Vector3(x, y, z) * rotateSpeed * Time.deltaTime);

        transform.position += new Vector3 (-translateSpeed * Time.deltaTime, -translateSpeed * Time.deltaTime, 0);

        if (transform.position.x < -30 || transform.position.y < -20) Destroy (gameObject);
    }
}