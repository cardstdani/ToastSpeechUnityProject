using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class exampleScript : MonoBehaviour
{
    public TextMeshProUGUI lenghtText;
    int lenght = 1;
    public voiceManager voiceScript;

    void Start()
    {
        //this is a simple call of a toast message, with the text and duration parameters
        toastManager.toast.ShowToast("The game has started!!", 1);
    }

    //this function calls a custom toast message with the text of the Input Text
    public void createCustomToastMessage(TMP_InputField textInput)
    {
        toastManager.toast.ShowToast(textInput.text, lenght);
        voiceScript.playSound(textInput.text, 0);
    }

    //do a toast message function
    public void doToastMessage(TextMeshProUGUI text)
    {
        toastManager.toast.ShowToast(text.text, 1);
    }

    //add lenght function
    public void addLenght()
    {
        if (lenght == 0) { lenght++; }
        lenghtText.text = lenght.ToString();
        toastManager.toast.ShowToast("Lenght increased to LONG", 1);
        voiceScript.playSound("Lenght decreased to LONG", 0);
    }

    //remove lenght function
    public void removeLenght()
    {
        if (lenght == 1) { lenght--; }
        lenghtText.text = lenght.ToString();
        toastManager.toast.ShowToast("Lenght decreased to SHORT", 0);
        voiceScript.playSound("Lenght decreased to SHORT", 0);
    }

    public void exitApplication()
    {
        Application.Quit();
    }
}