using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public Material material;

    public float speed;

    public Color currentColor;

    [Range(0,256)]
    public float r;
    [Range(0,256)]
    public float g;
    [Range(0,256)]
    public float b;

    public bool changingRed;

    private void Update  () {
        if (changingRed) {
            currentColor.r += multiplier * speed * Time.deltaTime / 256;

            if (currentColor.r <= 0f) {
                changingRed = !changingRed;
                speed *= -1;
            }

            if (currentColor.r >= 1) speed *= -1;
        } else {
            currentColor.g += multiplier * speed * Time.deltaTime/ 256;

            if (currentColor.g <= 0f) {
                changingRed = !changingRed;
                speed *= -1;
            }

            if (currentColor.g >= 1) speed *= -1;
        }

        r = currentColor.r * 256;
        g = currentColor.g * 256;
        b = currentColor.b * 256;

        material.color = currentColor;
    }

    public float multiplier {
        get {
            float nb = Mathf.Clamp(1/(currentColor.r + currentColor.g), 1, 3);
            return nb;
        }
    }
}