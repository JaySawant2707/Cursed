using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] List<string> dialogues;
    [SerializeField] TextMeshProUGUI dialogueText;

    int count = 0;

    void Start()
    {
        if (dialogues != null)
            dialogueText.text = " ";
    }

    public void NextDialogue()
    {
        if (count < dialogues.Count)
        {
            dialogueText.text = dialogues[count];
            count++;
        }
    }
}
