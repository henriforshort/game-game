using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public Material material;

    public float speed;

    public Color currentColor;

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

        material.color = currentColor;
    }

    public float multiplier {
        get {
            return Mathf.Clamp(1/(currentColor.r + currentColor.g), 1, 3);
        }
    }
}