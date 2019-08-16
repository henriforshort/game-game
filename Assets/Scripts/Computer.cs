using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactible {
    public List<string> games;
    public List<string> genres;
    public List<string> adjectives;

    protected override string GetText() {
        string text = base.GetText();

        text = text.Replace("[game]", games[Random.Range(0, games.Count - 1)]);
        text = text.Replace("[genre]", genres[Random.Range(0, genres.Count - 1)]);
        text = text.Replace("[adjective]", adjectives[Random.Range(0, adjectives.Count - 1)]);


        return text;
    }
}