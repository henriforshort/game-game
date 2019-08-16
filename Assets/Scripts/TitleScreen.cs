using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {
    public GameObject startText;

    private void Start () {
        StartCoroutine(FlashStart());
    }

    private IEnumerator FlashStart () {
        while (true) {
            startText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            startText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update () {
        if (hinput.gamepad[0].A.justPressed || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            gameObject.SetActive(false);
        }
    }
}