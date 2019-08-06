using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {
    public float lettersPerSec;
    public TMP_Text text;
    public static DialogManager instance;
    public GameObject background;

    public enum S { OFF, READING, SKIPPING, DONE }
    public S state;

    public void Awake () {
        instance = this;
    }

    public void Update () {
        if (state == S.DONE && hinput.gamepad[0].A.justPressed) {
            text.text = "";
            background.SetActive(false);
            state = S.OFF;
        }
    }

    public void Display (string s) {
        if (state == S.OFF) {
            state = S.READING;
            StartCoroutine(_Display(s));
        }
    }

    private IEnumerator _Display (string s) {
        background.SetActive(true);
        text.text = "";
        foreach (char c in s) {
            text.text += c;
            if (state != S.SKIPPING) {
                yield return new WaitForSeconds (1/lettersPerSec);
            }
        }
        state = S.DONE;
    }
}