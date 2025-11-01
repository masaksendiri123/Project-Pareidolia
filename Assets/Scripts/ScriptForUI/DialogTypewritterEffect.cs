using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;
using Unity.PlasticSCM.Editor.WebApi;
using System.Threading.Tasks;
using System.Threading;
using System;

public class DialogTypewritterEffect : MonoBehaviour
{
    public InputActionReference SkippingAction;
    bool isReadyForNextDialog;
    bool loopCharacterDone;

    TMPro.TextMeshProUGUI dialogTextUI;

    [Header("Untuk Atur Delay Character pada Inspector")]
    public float NormalCharacterDelay;
    public float InterpunctuationCharacterDelay;

    [Header("Untuk WaitForSeconds Delay Character")]
    private WaitForSeconds normalCharacterWait;
    private WaitForSeconds interpunctuationCharacterWait;

    [Header("Untuk Index Antar Kalimat dan Antar Character")]
    private int sentenceIndex;
    private int charIndex;

    private string currentDialog;

    private void Awake()
    {
        SkippingAction.action.started += skipDialog;
    }
    public void Start()
    {
        //Inisialisasi WaitForSeconds untuk delay karakter
        normalCharacterWait = new WaitForSeconds(NormalCharacterDelay);
        interpunctuationCharacterWait = new WaitForSeconds(InterpunctuationCharacterDelay);
    }

    // Memulai Proses Penulisan Dialog
    public void Write(List<string> dialogs)
    {
        dialogTextUI = GetComponent<TMPro.TextMeshProUGUI>();
        Coroutine m_writing = StartCoroutine(TypeWritterEffect(dialogs));
    }

    IEnumerator TypeWritterEffect(List<string> dialogs)
    {

        for (sentenceIndex = 0; sentenceIndex < dialogs.Count; sentenceIndex++)
        {
            isReadyForNextDialog = false;

            dialogTextUI.text = ""; // Clear previous text

            currentDialog = dialogs[sentenceIndex]; //Ngeset Kalimat mana yang mau ditampilin

            for (charIndex = 0; charIndex < currentDialog.Length; charIndex++)
            {
                char currentCharacter = currentDialog[charIndex];
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
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) && isReadyForNextDialog);
        }
        FindObjectOfType<OpenUIForDialogAndNote>().ClearDialog();
    }

    private void skipDialog(InputAction.CallbackContext callbackContext)
    {
        if (!isReadyForNextDialog)
        {
            isReadyForNextDialog = false;
            dialogTextUI.text = currentDialog; // Display full dialog
            charIndex = currentDialog.Length; // Exit the loop
            Invoke("SetReadyForNextDialog", 0.1f); // Small delay to prevent immediate skipping
        }
    }

    private void SetReadyForNextDialog()
    {
        isReadyForNextDialog = true;
    }
}