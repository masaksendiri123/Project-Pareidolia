using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenUIForDialogAndNote : MonoBehaviour
{

    //Untuk Ngecek Apakah Interacting Untuk Dialog Atau Note
    public enum TypeOfThisTextUIObject
    {
        Dialog,
        NoteBox,
        TextScene
    }
    
    public TypeOfThisTextUIObject currentTypeOfThisTextUIObject;
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
        if(currentTypeOfThisTextUIObject ==  TypeOfThisTextUIObject.Dialog)
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
                dialogTypewritterEffect.Write(textChatData.chatLines, SpecialCode, currentTypeOfThisTextUIObject);
                Debug.Log("Started Writing Dialog");

                textComponent = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log(textComponent);
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.Dialog;
            }
        }
        else if(currentTypeOfThisTextUIObject ==  TypeOfThisTextUIObject.NoteBox)
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
        else if (currentTypeOfThisTextUIObject == TypeOfThisTextUIObject.TextScene)
        {
            if (uiCanvasChildren.Count == 0)
            {
                uiCanvas = GameObject.FindGameObjectWithTag("SceneTextUI");

                for (int i = 0; i < uiCanvas.transform.childCount; i++)
                {
                    uiCanvasChildren.Add(uiCanvas.transform.GetChild(i).gameObject);
                    uiCanvasChildren[i].SetActive(true);
                
                }
            
                DialogTypewritterEffect dialogTypewritterEffect = uiCanvas.GetComponentInChildren<DialogTypewritterEffect>();
                dialogTypewritterEffect.Write(textChatData.chatLines, SpecialCode, currentTypeOfThisTextUIObject);
                Debug.Log("Started Writing Text In Scene");

                textComponent = uiCanvas.GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log(textComponent);
                FindObjectOfType<MovementStatusHandler>().CurrentMovementStatus = MovementStatusHandler.MovementStatus.Scene;
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
