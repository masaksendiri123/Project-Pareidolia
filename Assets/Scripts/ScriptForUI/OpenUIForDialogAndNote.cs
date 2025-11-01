using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenUIForDialogAndNote : MonoBehaviour
{

    //Untuk Ngecek Apakah Interacting Untuk Dialog Atau Note
    public bool IsThisGameObjectForDialog;
    public string SpecialCode;

    //Menyimpan data Canvas UI dan TextChatData
    GameObject uiCanvas;
    TextMeshProUGUI textComponent;
    public TextChatData textChatData;

    List<GameObject> uiCanvasChildren = new List<GameObject>();

    private void Start()
    {
        
    }

    public void OnInteract()
    {
        if(IsThisGameObjectForDialog)
        {
            if (uiCanvasChildren.Count == 0)
            {
                uiCanvas = GameObject.FindGameObjectWithTag("ChatBoxUI");
                for (int i = 0; i < uiCanvas.transform.childCount; i++)
                {
                    uiCanvasChildren.Add(uiCanvas.transform.GetChild(i).gameObject);
                    uiCanvasChildren[i].SetActive(true);
                }

                DialogTypewritterEffect dialogTypewritterEffect = uiCanvas.GetComponentInChildren<DialogTypewritterEffect>();
                dialogTypewritterEffect.Write(textChatData.chatLines, SpecialCode);
                Debug.Log("Started Writing Dialog");

                textComponent = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log(textComponent);
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.Dialog;
            }
        }
        else
        {
            uiCanvas = GameObject.FindGameObjectWithTag("NoteBoxUI");

            if (uiCanvasChildren.Count == 0)
            {
                for (int i = 0; i < uiCanvas.transform.childCount; i++)
                {
                    uiCanvasChildren.Add(uiCanvas.transform.GetChild(i).gameObject);
                    uiCanvasChildren[i].SetActive(true);
                }

                textComponent = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                textComponent.text = textChatData.chatLines[0];
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.CanNotMove;
            }
            else
            {

                TextMeshProUGUI noteText = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                noteText.text = "";

                for (int i = 0; i < uiCanvasChildren.Count; i++)
                {
                    uiCanvasChildren[i].SetActive(false);
                }

                uiCanvasChildren.Clear();
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.CanMove;
            }
        }
    }

    public void ClearDialog()
    {
        textComponent.text = "";

        for(int i = 0; i < uiCanvas.transform.childCount; i++)
        {
            uiCanvasChildren[i].SetActive(false);
        }

        uiCanvasChildren.Clear();
        FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.CanMove;
    }
}
