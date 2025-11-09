using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public OpenUIForDialogAndNote OpeningScene;
    public OpenUIForDialogAndNote Ending1Scene;
    public OpenUIForDialogAndNote Ending2Scene;

    private void Start()
    {
        Debug.Log("Story Dimulai");
        OpeningScene.OnInteract();
    }


    //Story Manager akan terpisah menjadi dua yang pertama dibagian atas adalah untuk alur cerita timeline maju,
    //lalu yang dibagian bawah adalah bagian untuk ngehandle alur cerita yang ada di tengah-tengah, event apalah itu


    // Dibawah Ini Alur Cerita Maju
    public void ClearingTheCrashSite()
    {
        //Masukin Script Buat Nunjukin Quest ngumpulin barang bukti
    }

    public void DoneClearingTheCrashSite()
    {
        //Masukan script untuk nutup Quest ngumpuling barang bukri

        //Masukan Script untuk pergi ke mobil untuk pergi dari tempat TKP

    }

    public void DoneKaburDariTKPNaikMobil()
    {
        //Masukin script untuk nutup Quest pergi dari TKP naik mobil

        //Masukin Script untuk buka Text Scene mengenai dia mendapat tugas untuk menginvestigasi kasus ia sendiri
    }
}
