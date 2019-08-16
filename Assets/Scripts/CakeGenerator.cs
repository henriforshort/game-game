using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeGenerator : MonoBehaviour {
    List<Cake> cakes = new List<Cake>();
    public Cake cakePrefab;
    static float duration = 5;
    float timeLeft = duration;

    private void Start () {
        for (int i=0; i<10; i++) {
            GenerateCakeLine(i);
        }
    }

    private void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) {
            timeLeft = duration;
            GenerateCakeLine (0);
        }
    }

    private void GenerateCakeLine (float offset) {
        for (int i=0; i<10; i++) {
            cakes.Add(
                Instantiate(
                    cakePrefab,
                    new Vector3 (5, 45, 60) + i * new Vector3 (4, -4, 0) + offset * new Vector3(-5, -5, 0),
                    Quaternion.identity,
                    transform
                )
            );
        }
    }
}