using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUIScript : MonoBehaviour
{
    private string currentText;
    private int jumlahCompletion;
    private int currentCompletion;

    private string NamaFunctionYangDipanggilSetelahObjectiveSelesai;

    [SerializeField] private TextMeshProUGUI ObjectiveTask;
    [SerializeField] private TextMeshProUGUI ObjectiveCount = null;

    public void SetObjective(string m_namaTask, int m_jumlahTugas, string m_namaFunctionSetelahObjectiveSelesai, string m_tipeObjective)
    {
        gameObject.SetActive(true);

        currentText = m_namaTask;
        jumlahCompletion = m_jumlahTugas;
        NamaFunctionYangDipanggilSetelahObjectiveSelesai = m_namaFunctionSetelahObjectiveSelesai;

        ObjectiveTask.text = currentText;

        if (m_tipeObjective == "Progression")
        {
            ObjectiveCount.text = "0/" + jumlahCompletion.ToString() ;
        }
    }

    public void UpdateObjectiveCount()
    {
        currentCompletion += 1;
        ObjectiveCount.text = currentCompletion.ToString() + "/" + jumlahCompletion.ToString();

        if (currentCompletion >= jumlahCompletion)
        {
            ClearObjective("Progression");
        }
    }

    public void ClearObjective(string m_tipeObjective)
    {
        ObjectiveTask.text = "";

        if (m_tipeObjective == "Progression")
        {
            ObjectiveCount.text = "0/0";
        }

        FindObjectOfType<StoryManager>().SendMessage(NamaFunctionYangDipanggilSetelahObjectiveSelesai);

        gameObject.SetActive(false);
    }
}
