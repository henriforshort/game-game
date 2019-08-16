using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactible {
    public GameObject eyes;
    public float speed;

    public override void BeforeInteract() {
        StartCoroutine (ShowEyes());
    }

    public IEnumerator ShowEyes () {
        Material mat = eyes.GetComponent<MeshRenderer>().material;

        eyes.SetActive(true);

        while (mat.color.a < 1) {
            AddA(mat, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame ();
        }
        yield return new WaitForSeconds (1);

        StartCoroutine(HideEyes());
    }

    public IEnumerator HideEyes () {
        Material mat = eyes.GetComponent<MeshRenderer>().material;
        
        while (mat.color.a > 0) {
            AddA(mat, - speed * Time.deltaTime);
            yield return new WaitForEndOfFrame ();
        }
        eyes.SetActive(false);

        Interact ();
    }
    
    private void AddA (Material mat, float value) 
        => mat.color = new Color (mat.color.r, mat.color.g, mat.color.b, mat.color.a + value);
}