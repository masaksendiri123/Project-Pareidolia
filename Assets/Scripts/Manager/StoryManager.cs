using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    private string tipeObjectiveProgress = "Progression";
    private string tipeObjectiveCompletion = "Completion";

    public Task[] Tasks;

    public OpenUIForDialogAndNote OpeningScene;
    public OpenUIForDialogAndNote Ending1Scene;
    public OpenUIForDialogAndNote Ending2Scene;
    public OpenUIForDialogAndNote SceneTextKetikaMasukMobil;
    public OpenUIForDialogAndNote SceneTextKetikaMasukRumah;

    [Header("UI Task")]
    public GameObject ProgressObjective;
    public GameObject CompletionObjective;

    public void AddingProgressObjective()
    {
        ProgressObjective.GetComponent<ObjectiveUIScript>().UpdateObjectiveCount();
    }

    public void DoneDoCompletionObjective()
    {
        Debug.Log("Di Story manager");

        CompletionObjective.GetComponent<ObjectiveUIScript>().ClearObjective("");
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


    //Harus Diubah Manual
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Town (Act3)")
        {
            PergiKeRumahKorban();
        }
        else if (scene.name == "RumahKorban")
        {
            WawancaraKeluaraga();
        }
    }

    void Awake()
    {
        // Supaya GameObject ini tidak dihancurkan saat load scene baru
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        Debug.Log("Story Dimulai");
        OpeningScene.OnInteract(); //Untuk Buka Scene Text Opening
        ClearingTheCrashSite();
    }


    //Story Manager akan terpisah menjadi dua yang pertama dibagian atas adalah untuk alur cerita timeline maju,
    //lalu yang dibagian bawah adalah bagian untuk ngehandle alur cerita yang ada di tengah-tengah, event apalah itu


        // Dibawah Ini Alur Cerita Maju
    public void ClearingTheCrashSite()
    {
        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        ProgressObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveProgress);
    }

    public void DoneClearingTheCrashSite()
    {
        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        CompletionObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveCompletion);
    }

    public void DoneKaburDariTKPNaikMobil()
    {
        SceneManager.LoadScene("Town (Act3)");
    }

    public void PergiKeRumahKorban()
    {
        SceneTextKetikaMasukMobil.OnInteract();

        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        CompletionObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveCompletion);
    }

    public void MasukRumah()
    {
        SceneManager.LoadScene("RumahKorban");
    }

    public void WawancaraKeluaraga()
    {
        SceneTextKetikaMasukMobil.OnInteract();

        var dataTask = MendapatkanDataDariArrayTasks(MethodBase.GetCurrentMethod().Name);
        int jumlahProgressObjective = FindAnyObjectByType<ProgressObjectiveManager>().totalSeluruhSampah;
        CompletionObjective.GetComponent<ObjectiveUIScript>().SetObjective(dataTask.textYangDitampilkanDiTask, jumlahProgressObjective, dataTask.namaFunctionYangDijalankanSetelahTask, tipeObjectiveCompletion);
    }
}
