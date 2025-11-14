using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionObjectiveScript : MonoBehaviour
{
    public OpenUIForDialogAndNote ScriptUntukBukaUIDialogJikaDiperlukan = null;

    public void OnInteract()
    {
        Debug.Log("Interaksi Dilakukan");

        FindFirstObjectByType<StoryManager>().DoneDoCompletionObjective();
        if (ScriptUntukBukaUIDialogJikaDiperlukan != null)
            ScriptUntukBukaUIDialogJikaDiperlukan.OnInteract();

        Destroy(gameObject);
    }
}
