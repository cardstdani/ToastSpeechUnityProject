using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class voiceManager : MonoBehaviour
{
    public AudioSource audio;
    [Tooltip("All your language codes here")]
    public List<string> languageCode;

    /*
     Language codes:

     en | english
     es | spanish
     fr | french
     de | german
     ru | russian
     it | italian
         */

    int currentLanguage;
    string text;

    private void Start()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }

        audio = GetComponent<AudioSource>();
    }

    public void playSound(string newText, int language)
    {
        if (newText.Length != 0)
        {
            currentLanguage = language;
            text = newText;
            StartCoroutine(getAudio());
        }
        else { toastManager.toast.ShowToast("There is no text to convert", 1); }
    }

    IEnumerator getAudio()
    {
        string URL = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + text + "&tl=" + languageCode[currentLanguage];
        WWW www = new WWW(URL);
        yield return www;

        audio.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        audio.Play();
    }
}