using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour {
    public MeshRenderer overlay;
    public string text;

    public void Interact () {
        DialogManager.instance.Display(text);
    }
}