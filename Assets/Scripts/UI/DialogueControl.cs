using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    private Animator animation;
    private Queue<string> dialogues;
    Text texto;
    [SerializeField] TextMeshProUGUI screenText;
   
    public void ActivateCartel(Text objectText)
    {
        animation.SetBool("Cartel", true);
        texto = objectText;
    }
    public void ActivaTexto()
    {
        dialogues.Clear();
        foreach(string saveText in texto.arrayTextos)
        {
            dialogues.Enqueue(saveText);
        }
        NextPhrase();
    }
    public void NextPhrase()
    {
        if(dialogues.Count == 0)
        {
            CloseCartel();
            return;
        }
        string currentPhrase = dialogues.Dequeue();
        screenText.text = currentPhrase;
        StartCoroutine(ShowCharacters(currentPhrase));
    }
    IEnumerator ShowCharacters (string textToShow)
    {
        screenText.text += "";
        foreach (char character in textToShow.ToCharArray())
        {
            screenText.text += character;
            yield return new WaitForSeconds(0.02f);
        }
    }
    void CloseCartel()
    {
        animation.SetBool("Cartel", false);  
    }
}
