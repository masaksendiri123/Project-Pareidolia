using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System.Threading;
using System;

public class DialogTypewritterEffect : MonoBehaviour
{

    [Header("Input Action Reference untuk Skip Dialog")]
    public InputActionReference SkippingAction;
    bool isReadyForNextDialog;
    bool usingSkip;

    [Header("TextMeshPro UGUI Component untuk Dialog")]
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

    [Header("Untuk Menyimpan Kalimat yang Sedang Ditampilkan")]
    private string currentDialog;

    private OpenUIForDialogAndNote.TypeOfThisTextUIObject typeOfThisTextUIObject;
    private string specialCode;

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
    public void Write(List<string> dialogs, string m_specialCode, OpenUIForDialogAndNote.TypeOfThisTextUIObject  type)
    {
        dialogTextUI = GetComponent<TMPro.TextMeshProUGUI>();
        specialCode = m_specialCode;
        typeOfThisTextUIObject = type;
        Coroutine m_writing = StartCoroutine(TypeWritterEffect(dialogs));
    }

    IEnumerator TypeWritterEffect(List<string> dialogs)
    {

        for (sentenceIndex = 0; sentenceIndex < dialogs.Count; sentenceIndex++)
        {
            isReadyForNextDialog = false;
            usingSkip = false;

            dialogTextUI.text = ""; // Clear previous text

            currentDialog = dialogs[sentenceIndex]; //Ngeset Kalimat mana yang mau ditampilin

            for (charIndex = 0; charIndex < currentDialog.Length; charIndex++)
            {
                char currentCharacter = currentDialog[charIndex];
                string checkBRCommand  = "";

                for (int i = 0; i < 4; (i)++)
                {
                    if (charIndex + i < currentDialog.Length)
                    {
                        checkBRCommand += currentDialog[charIndex + i].ToString();
                    }
                    else break;
                }

                if (checkBRCommand == "<br>")
                {
                    dialogTextUI.text += "<br>";
                    charIndex += 3;
                }
                else
                {
                    dialogTextUI.text += currentCharacter; // Add character to UI
                }

                if (typeOfThisTextUIObject  == OpenUIForDialogAndNote.TypeOfThisTextUIObject.TextScene)
                {
                    FindObjectOfType<AudioManager>().Play("KeyboardClickSound");
                }

                if (currentCharacter == '.' || currentCharacter == ',' || currentCharacter == '!' || currentCharacter == '?')
                {

                    yield return interpunctuationCharacterWait;
                }
                else
                {
                    yield return normalCharacterWait;
                }
            }
            if (usingSkip == false)
            {
                isReadyForNextDialog = true;
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E) && isReadyForNextDialog);
        }
        //FindObjectsOfType<OpenUIForDialogAndNote>().ClearDialog(dialogTextUI);

        OpenUIForDialogAndNote[] allScript = FindObjectsByType<OpenUIForDialogAndNote>(FindObjectsSortMode.None);

        foreach (OpenUIForDialogAndNote script in allScript)
        {
            if (script.SpecialCode == specialCode)
            {
                script.ClearDialog();
            }
        }
    }

    private void skipDialog(InputAction.CallbackContext callbackContext)
    {
        if (!isReadyForNextDialog)
        {
            usingSkip = true;

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
