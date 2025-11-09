using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingEvidenceItem : MonoBehaviour
{
    public void OnInteract()
    {
        FindAnyObjectByType<TakingEvidenceManger>().SaatSampahDikumpulkan();
        Destroy(gameObject);
    }
}
