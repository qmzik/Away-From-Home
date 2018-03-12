using UnityEngine;

public class StartDialog : MonoBehaviour {

    public GameObject info;
    public Dialogue dialogue;

    bool canIStartDialogue = false;
    bool isDialogueStarted = false;

    private void Start()
    {
        info.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canIStartDialogue && !isDialogueStarted)
        {
            info.SetActive(false);
            FindObjectOfType<DialogueManager>().StartConversation(dialogue);
            isDialogueStarted = true;
        }

        if(Input.GetKeyDown(KeyCode.F) && isDialogueStarted)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDialogueStarted)
        {
            info.SetActive(true);
            canIStartDialogue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        info.SetActive(false);
        canIStartDialogue = false;
    }
}
