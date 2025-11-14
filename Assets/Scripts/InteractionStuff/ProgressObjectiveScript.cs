using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressObjectiveScript : MonoBehaviour
{
    public OpenUIForDialogAndNote ScriptUntukBukaUIDialogJikaDiperlukan = null;

    public void OnInteract()
    {
        FindFirstObjectByType<ProgressObjectiveManager>().ProgressDilaksanakan();
        if (ScriptUntukBukaUIDialogJikaDiperlukan != null) 
            ScriptUntukBukaUIDialogJikaDiperlukan.OnInteract();

        Destroy(gameObject);
    }
}
