using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Dorian dorian;

    void Update () {
        transform.position = dorian.transform.position + 10*Vector3.back;
    }
}