using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    /*public Dialogue answer1dialogue;
    public Dialogue answer2dialogue;
    public Dialogue answer3dialogue;*/
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue/*,answer1dialogue,answer2dialogue,answer3dialogue*/);
    }
}
