using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressObjectiveManager : MonoBehaviour
{
    public int totalSeluruhSampah;

    private void Awake()
    {
        ProgressObjectiveScript[] allEvidenceItem = FindObjectsByType<ProgressObjectiveScript>(FindObjectsSortMode.None);
        totalSeluruhSampah = allEvidenceItem.Length;
        Debug.Log("Total Sampah: " + totalSeluruhSampah);
    }

    public void ProgressDilaksanakan()
    {
        FindObjectOfType<StoryManager>().AddingProgressObjective();
    }
}