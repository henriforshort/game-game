using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorian : MonoBehaviour {

    public float speed;
    public Rigidbody2D rig;
    public DialogManager dialogManager;
    public Interactible closestInteractible;
    public List<Arrow> legs;

    hGamepad gamepad { get { return hinput.gamepad[0]; } }

    private void Update () {
        if (DialogManager.instance.state != DialogManager.S.READING
        && DialogManager.instance.state != DialogManager.S.DONE) {
            rig.AddForce(gamepad.leftStick.worldPositionCamera * speed * Time.deltaTime);
        }

        if (gamepad.leftStick.inPressedZone) {
            
            transform.rotation = Quaternion.Euler(new Vector3 (
                transform.rotation.x, 
                transform.rotation.y, 
                gamepad.leftStick.angle
            ));

            foreach(Arrow leg in legs) {
                leg.isStopped = false;
            }
        } else {
            foreach(Arrow leg in legs) {
                leg.isStopped = true;
            }
        }

        if (gamepad.A.justPressed) {
            if (dialogManager.state == DialogManager.S.READING) dialogManager.state = DialogManager.S.SKIPPING;
            if (dialogManager.state == DialogManager.S.OFF) closestInteractible.Interact();
        }
    }


    private void OnTriggerEnter2D (Collider2D collider) {
        Interactible interactible = collider.GetComponent<Interactible>();
        if (interactible && interactible.canInteract) {
            foreach(MeshRenderer mr in interactible.overlay) mr.enabled = true;
            closestInteractible = interactible;
        }
    }


    private void OnTriggerExit2D (Collider2D collider) {
        Interactible interactible = collider.GetComponent<Interactible>();
        if (interactible) {
            foreach(MeshRenderer mr in interactible.overlay) mr.enabled = false;
            closestInteractible = null;
        }
    }
}