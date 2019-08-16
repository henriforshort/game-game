using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour {
    public List<MeshRenderer> overlay;
    public int previousLine;
    [TextArea]
    public List<string> text;
    public bool canInteract;

    public virtual void BeforeInteract () {
        Interact ();
    }

    protected void Interact () {
        if (canInteract) {
            DialogManager.instance.Display(GetText());
        }

        AfterInteract ();
    }

    protected virtual void AfterInteract () { }

    protected virtual string GetText () {
        int randomNumber = Random.Range(0, text.Count);

        if (text.Count > 1) {
            while (randomNumber == previousLine) {
                randomNumber = Random.Range(0, text.Count);
            }
        }

        previousLine = randomNumber;

        return text [randomNumber];
    }
}