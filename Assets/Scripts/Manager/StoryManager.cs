using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private string tipeObjectiveProgress = "Progression";
    private string tipeObjectiveCompletion = "Completion";

    public Task[] Tasks;

    public OpenUIForDialogAndNote OpeningScene;
    public OpenUIForDialogAndNote Ending1Scene;
    public OpenUIForDialogAndNote Ending2Scene;

    [Header("UI Task")]
    public GameObject ProgressObjective;
    public GameObject CompletionObjective;

    public void AddingProgressObjective()
    {
        ProgressObjective.GetComponent<ObjectiveUIScript>().UpdateObjectiveCount();
    }

    private (string namaTask, string textYangDitampilkanDiTask, string namaFunctionYangDijalankanSetelahTask) MendapatkanDataDariArrayTasks(string m_namaFunction)
    {
        foreach (Task task in Tasks)
        {
            if (task.NamaTask == m_namaFunction)
            {
                return (task.NamaTask, task.TextYangDitampilkanTask, task.NamaFunctionYangDijalankanSetelahTaskSelesai);
            } 
        }
        return ("", "", "");
    }


    private void Start()
    {
        Debug.Log("Story Dimulai");
        OpeningScene.OnInteract();
        ClearingTheCrashSite();
    }


    //Story Manager akan terpisah menjadi dua yang pertama dibagian atas adalah untuk alur cerita timeline maju,
    //lalu yang dibagian bawah adalah bagian untuk ngehandle alur cerita yang ada di tengah-tengah, event apalah itu


        // Dibawah Ini Alur Cerita Maju
    public void ClearingTheCrashSite()
    {
        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        Debug.Log(jumlahProgressObjective);
        ProgressObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveProgress);
    }

    public void DoneClearingTheCrashSite()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        CompletionObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveCompletion);
    }

    public void DoneKaburDariTKPNaikMobil()
    {
        //Masukin script untuk nutup Quest pergi dari TKP naik mobil

        //Masukin Script untuk buka Text Scene mengenai dia mendapat tugas untuk menginvestigasi kasus ia sendiri
    }
}
