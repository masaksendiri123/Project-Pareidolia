using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTypewritterEffect : MonoBehaviour
{
    TMPro.TextMeshProUGUI dialogTextUI;

    public float NormalCharacterDelay;
    public float InterpunctuationCharacterDelay;

    private WaitForSeconds normalCharacterWait;
    private WaitForSeconds interpunctuationCharacterWait;

    public void Start()
    {
        normalCharacterWait = new WaitForSeconds(NormalCharacterDelay);
        interpunctuationCharacterWait = new WaitForSeconds(InterpunctuationCharacterDelay);

        dialogTextUI = GetComponent<TMPro.TextMeshProUGUI>();

        Write();
    }
    public void Write()
    {
        Coroutine m_writing = StartCoroutine(TypeWritterEffect("Your dialog text goes here."));
    }

    IEnumerator TypeWritterEffect(string dialogText)
    {
        dialogTextUI.text = ""; // Clear previous text
        for (int i = 0; i < dialogText.Length; i++)
        {
            char currentCharacter = dialogText[i];
            dialogTextUI.text += currentCharacter; // Add character to UI text
            if (currentCharacter == '.' || currentCharacter == ',' || currentCharacter == '!' || currentCharacter == '?')
            {
                yield return interpunctuationCharacterWait;
            }
            else
            {
                yield return normalCharacterWait;
            }
        }
        Debug.Log("Coroutine Finish");
    }
}
