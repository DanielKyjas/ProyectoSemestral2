using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PuertaPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(2,6)] private string[] dialogueLines;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Movimiento_Chamaco1 chamaco;
    [SerializeField] private GameObject pausebotton;
    [SerializeField] private GameObject startMenu;
    private bool playerInteraction;
    private bool didDialogueStart;
    private int lineIndex;
    private float typingTime = 0.03f;


    // Update is called once per frame
    void Update()
    {
        if (gameManager.KeysObtained != 3) {
            if (playerInteraction && Input.GetKeyDown(KeyCode.E))
            {
                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
            }
        }
        else
        {
            if (playerInteraction && Input.GetKeyDown(KeyCode.E))
            {
                pausebotton.SetActive(false);
                startMenu.SetActive(true);
                PlayerPrefs.DeleteAll();
                
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
