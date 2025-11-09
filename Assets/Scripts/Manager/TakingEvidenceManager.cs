using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingEvidenceManger : MonoBehaviour
{
    private int JumlahSampahSekarang;
    private int totalSeluruhSampah;

    void Start()
    {
        TakingEvidenceItem[] allEvidenceItem = FindObjectsByType<TakingEvidenceItem>(FindObjectsSortMode.None);
        totalSeluruhSampah =  allEvidenceItem.Length;
        Debug.Log("Total Sampah: " + totalSeluruhSampah);
    }

    public void SaatSampahDikumpulkan()
    {
        JumlahSampahSekarang += 1;
        if (JumlahSampahSekarang >= totalSeluruhSampah)
        {
            //Jalankan Perintah Disini Jika Sampah Sudah Terkumpul Semua
            Debug.unityLogger.Log("Sampah Selesai Dikumpulkan");
        }
    }
}