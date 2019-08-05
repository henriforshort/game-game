using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorian : MonoBehaviour {

    public float speed;
    public Rigidbody2D rig;
    public DialogManager dialogManager;

    hGamepad gamepad { get { return hinput.gamepad[0]; } }

    private void Update () {
        rig.AddForce(gamepad.leftStick.worldPositionCamera * speed * Time.deltaTime);
        if (gamepad.A.justPressed) dialogManager.Display("Hello !Hello !Hello !Hello !Hello !Hello !Hello !Hello !");
        if (gamepad.B) dialogManager.skipText = true;
    }


    private void OnTriggerEnter (Collider collider) {
        Debug.Log("on1");
        Interactible interactible = collider.GetComponent<Interactible>();
        if (interactible) {
            interactible.overlay.enabled = true;
            Debug.Log("on");
        }
    }
}