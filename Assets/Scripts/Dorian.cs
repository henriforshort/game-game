using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dorian : MonoBehaviour {

    public float speed;
    public Rigidbody2D rig;
    public DialogManager dialogManager;
    public Interactible closestInteractible;
    public List<Foot> legs;

    hGamepad gamepad { get { return hinput.gamepad[0]; } }

    private void Update () {
            Vector3 stickPosition = gamepad.leftStick.worldPositionCamera * speed * Time.deltaTime;
            Vector3 buttonPosition = new Vector3 ();
            if (Input.GetKey(KeyCode.LeftArrow)) buttonPosition += Vector3.left;
            if (Input.GetKey(KeyCode.RightArrow)) buttonPosition += Vector3.right;
            if (Input.GetKey(KeyCode.UpArrow)) buttonPosition += Vector3.up;
            if (Input.GetKey(KeyCode.DownArrow)) buttonPosition += Vector3.down;
            buttonPosition *= speed * Time.deltaTime;

            Vector3 moveVector;
            if (stickPosition.magnitude > buttonPosition.magnitude) moveVector = stickPosition;
            else moveVector = buttonPosition;

        if (DialogManager.instance.state != DialogManager.S.READING
        && DialogManager.instance.state != DialogManager.S.DONE) {
            rig.AddForce(moveVector);
        }

        if (moveVector.magnitude > 10f) {
            transform.rotation = Quaternion.Euler(new Vector3 (
                transform.rotation.x, 
                transform.rotation.y, 
                Vector3.SignedAngle(Vector3.right, moveVector, Vector3.forward)
            ));
        }

        if (rig.velocity.magnitude < 1f) foreach (Foot foot in legs) foot.moving = false;
        else foreach (Foot foot in legs) foot.moving = true;

        if (gamepad.A.justPressed || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            if (dialogManager.state == DialogManager.S.READING) dialogManager.state = DialogManager.S.SKIPPING;
            if (dialogManager.state == DialogManager.S.OFF && closestInteractible) closestInteractible.BeforeInteract();
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