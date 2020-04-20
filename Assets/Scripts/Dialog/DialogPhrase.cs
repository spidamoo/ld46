using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogPhrase
{
    public string text;
    public string englishText;
    public AudioClip sound;

    public string GetText(bool wantEnglish)
    {
        if (wantEnglish && englishText.Length > 0)
            return englishText;
        return text;
    }
}
