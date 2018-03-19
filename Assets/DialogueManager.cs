using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public GameObject dialoguePanel;

    private HeroController heroController;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        heroController = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroController>();
	}
	

	public void StartConversation(Dialogue dialogue)
    {
        heroController.enabled = false;
        dialoguePanel.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndConversation();

            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndConversation()
    {
        dialoguePanel.SetActive(false);
        heroController.enabled = true;
    }
}
