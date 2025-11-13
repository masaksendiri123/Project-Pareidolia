using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectThatDissapearWhenGetClose : MonoBehaviour
{

    public UnityEvent HappeningAfterGetCose;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HappeningAfterGetCose.Invoke();
            Destroy(gameObject);
        }
    }
}