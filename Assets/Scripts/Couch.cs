using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : Interactible {
    public SubEmployee subEmployee;

    protected override string GetText () {
        canInteract = false;
        subEmployee.canInteract = true;
        subEmployee.giantArrow.SetActive(false);

        return base.GetText();
    }
}