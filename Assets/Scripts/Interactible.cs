using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour {
    public MeshRenderer overlay;

    private void OnTriggerEnter (Collider collider) {
            Debug.Log("on");
        if (collider.GetComponent<Dorian>()) {
            overlay.enabled = true;
            Debug.Log("on");
        }
    }

    private void OnTriggerExit (Collider collider) {
        if (collider.GetComponent<Dorian>()) {
            overlay.enabled = false;
            Debug.Log("off");
        }
    }
}