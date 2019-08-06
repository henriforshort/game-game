using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorian : MonoBehaviour {

    public float speed;
    public Rigidbody2D rig;
    public DialogManager dialogManager;
    public Interactible closestInteractible;

    hGamepad gamepad { get { return hinput.gamepad[0]; } }

    private void Update () {
        rig.AddForce(gamepad.leftStick.worldPositionCamera * speed * Time.deltaTime);
        if (gamepad.A.justPressed) {
            if (dialogManager.state == DialogManager.S.READING) dialogManager.state = DialogManager.S.SKIPPING;
            else if (closestInteractible) closestInteractible.Interact();
        }
    }


    private void OnTriggerEnter2D (Collider2D collider) {
        Interactible interactible = collider.GetComponent<Interactible>();
        if (interactible) {
            interactible.overlay.enabled = true;
            closestInteractible = interactible;
        }
    }


    private void OnTriggerExit2D (Collider2D collider) {
        Interactible interactible = collider.GetComponent<Interactible>();
        if (interactible) {
            interactible.overlay.enabled = false;
            closestInteractible = null;
        }
    }
}