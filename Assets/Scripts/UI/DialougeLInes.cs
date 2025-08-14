using System;
using TMPro;
using UnityEngine;

public class DialougeLInes : MonoBehaviour
{
    [SerializeField] String[] timelineDialougeText;
    [SerializeField] TMP_Text dialougeText;

    int currentDialouge = 0;

    public void NextDialougeLine()
    {
        dialougeText.text = timelineDialougeText[currentDialouge];
        currentDialouge++;
    }
}