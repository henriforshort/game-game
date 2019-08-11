using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEmployee : Interactible {
    private bool dodoHasSub;
    public GameObject giantArrow;
    public Couch couch;

    public void Update () {
    }


    protected override string GetText() {
        string s = "hi, i'll have a large sub with ";

        s += Random.Range(0, 1) == 1 ? "a vegan steak, " : "quinoa steaks, ";

        List<int> ingredientIndexes = new List<int>();
        for (int i=0; i<4; i++) {

        int randomNumber = Random.Range(0, text.Count);

        while (ingredientIndexes.Contains(randomNumber)) {
            randomNumber = Random.Range(0, text.Count);
        }

        ingredientIndexes.Add(randomNumber);

        }

        for (int i = 0; i < ingredientIndexes.Count -1; i++){
            s += text[ingredientIndexes[i]] + ", ";
        }
        s += "and "+text[ingredientIndexes[ingredientIndexes.Count - 1]];
        s += " please";

        canInteract = false;
        couch.canInteract = true;
        giantArrow.SetActive(true);

        return s;
    }
}