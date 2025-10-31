using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenUIForDialogAndNote : MonoBehaviour
{

    //Untuk Ngecek Apakah Interacting Untuk Dialog Atau Note
    public bool IsThisGameObjectForDialog;

    //Menyimpan data Canvas UI dan TextChatData
    GameObject uiCanvas;
    public TextChatData textChatData;

    List<GameObject> uiCanvasChildren = new List<GameObject>();

    private void Start()
    {
        
    }

    public void OnInteract()
    {
        if(IsThisGameObjectForDialog)
        {
            uiCanvas = GameObject.FindGameObjectWithTag("ChatBoxUI");
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

                TextMeshProUGUI noteText = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                noteText.text = textChatData.chatLines[0];
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.CanNotMove;
            }
            else
            {

                TextMeshProUGUI noteText = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                noteText.text = "";

                for (int i = 0; i < uiCanvas.transform.childCount; i++)
                {
                    uiCanvasChildren[i].SetActive(false);
                }

                uiCanvasChildren.Clear();
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.CanMove;
            }
        }
    }
}
