using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nametext;
    public Text dialoguetext;
    public Text answer1text;
    public Text answer2text;
    public Text answer3text;
    public Queue<string> answers1;
    public Queue<string> answers2;
    public Queue<string> answers3;
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        answers1 = new Queue<string>();
        answers2 = new Queue<string>();
        answers3 = new Queue<string>();
    }

   public void StartDialogue(Dialogue dialogue/*,Dialogue answer1dialogue,Dialogue answer2dialogue,Dialogue answer3dialogue*/)
    {
        Debug.Log("We need to talk:"+ dialogue.name);
        nametext.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        answers1.Clear();
        foreach (string answer1 in dialogue.answers1)
        {
            answers1.Enqueue(answer1);
        }
        answers2.Clear();
        foreach (string answer2 in dialogue.answers2)
        {
            answers2.Enqueue(answer2);
        }   
        answers3.Clear();
        foreach (string answer3 in dialogue.answers3)
        {
            answers3.Enqueue(answer3);
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string answer1 = answers1.Dequeue();
        string answer2 = answers2.Dequeue();
        string answer3= answers3.Dequeue();
        Debug.Log(sentence);
        dialoguetext.text = sentence;
        answer1text.text = answer1;
        answer2text.text = answer2;
        answer3text.text = answer3;
    }  
    void EndDialogue()
    {
        Debug.Log("Ended");
    }
}
