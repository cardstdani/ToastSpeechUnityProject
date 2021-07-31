using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//toast integration script
namespace toastManager
{
    //toast class
    public class toast : MonoBehaviour
    {
        //this is the main function to make a toast call
        public static void ShowToast(string text, int duration)
        {
            if (text == "")
            {
                text = "Null text";
            }

            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

            object[] toastParams = new object[3];
            AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            toastParams[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
            toastParams[1] = text;

            //set the duration of the toast message, 0 for short duration and 1 for long duration
            if (duration == 0)
            {
                toastParams[2] = toastClass.GetStatic<int>("LENGTH_SHORT");
            }
            else
            {
                toastParams[2] = toastClass.GetStatic<int>("LENGTH_LONG");
            }

            //apply the parameters to the toast object and show it in the screen
            AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);
            toastObject.Call("show");
        }
    }
}