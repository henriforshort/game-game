using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour {
    public float lettersPerSec;
    public TMP_Text text;
    public bool skipText;
    public bool reading;

    public void Display (string s) {
        if (!reading) {
            reading = true;
            StartCoroutine(_Display(s));
        }
    }

    private IEnumerator _Display (string s) {
        text.text = "";
        foreach (char c in s) {
            text.text += c;
            if (!skipText) {
                yield return new WaitForSeconds (1/lettersPerSec);
            }
        }
        skipText = false;
        reading = false;
    }
}