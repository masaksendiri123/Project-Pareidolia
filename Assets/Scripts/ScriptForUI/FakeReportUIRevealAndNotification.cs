using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FakeReportUIRevealAndNotification : MonoBehaviour
{


    public InputActionReference OpenFakeReportUIAction;
    public GameObject FakeReportUIPage;
    public Image NotificationFakeReportBaru;
    public TextMeshProUGUI Tulisan;
    private bool SudahDiungkap = false;


    private void Start()
    {
        if(FakeReportUIPage != null)
        {
            OpenFakeReportUIAction.action.performed += MenampikanFakeReportUI;
        }
        else
        {
            Tulisan = GetComponent<TextMeshProUGUI>();
        }
    }

    public void FakeReportDiungkap()
    {
        if (!SudahDiungkap)
        {
            SudahDiungkap = true;
            NotificationFakeReportBaru.gameObject.SetActive(true);
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }

    private void MenampikanFakeReportUI(InputAction.CallbackContext context)
    {
        if (FakeReportUIPage == null)
            return;

        if(FakeReportUIPage.activeSelf) //jika page sudah dibuka
        {
            FakeReportUIPage.SetActive(false);
        }
        else //Jika page belum dibuka
        {
            FakeReportUIPage.SetActive(true);
            NotificationFakeReportBaru.gameObject.SetActive(false);
        }
    }
}
