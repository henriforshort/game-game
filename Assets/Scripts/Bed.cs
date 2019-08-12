using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactible {
    public GameObject eyes;
    public float speed;

    protected override void AfterInteract() {
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

        while (mat.color.a > 0) {
            AddA(mat, - speed * Time.deltaTime * 100);
            yield return new WaitForEndOfFrame ();
        }

        eyes.SetActive(false);
    }

    public void AddA (Material mat, float value) {
        mat.color = new Color (mat.color.r, mat.color.g, mat.color.b, mat.color.a + value);
    }
}