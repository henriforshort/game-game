using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactible {
    public SubEmployee subEmployee;
    public GameObject sub;

    protected override string GetText () {
        canInteract = false;
        subEmployee.canInteract = true;
        subEmployee.giantArrow.SetActive(false);
        sub.SetActive(false);

        return base.GetText();
    }
}