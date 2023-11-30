using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(2,6)] private string[] dialogueLines;
    [SerializeField] private Movimiento_Chamaco1 chamaco;
    private bool playerInteraction;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.02f;


    // Update is called once per frame
    void Update()
    {
        if (playerInteraction && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                typingTime = 0f;
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                typingTime = 0f;
                NextDialogueLine();
             
            }
            else if(dialogueText.text != dialogueLines[lineIndex])
            {

                typingTime = 0.02f;
            }
        }
    }
    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        chamaco.velocidadMovimiento = 0;
        chamaco.velocidadCorrer = 0;

    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            chamaco.velocidadMovimiento = 2.2f;
            chamaco.velocidadCorrer = 4.5f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            dialogueMark.SetActive(true);
            playerInteraction = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chamaco"))
        {
            dialogueMark.SetActive(false);
            playerInteraction = false;
        }
    }
}
