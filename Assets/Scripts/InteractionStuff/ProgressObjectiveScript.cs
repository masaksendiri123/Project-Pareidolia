using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressObjectiveScript : MonoBehaviour
{
    public void OnInteract()
    {
        FindFirstObjectByType<ProgressObjectiveManager>().ProgressDilaksanakan();
        Destroy(gameObject);
    }
}
