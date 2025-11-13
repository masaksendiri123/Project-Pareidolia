using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThatDissapearWhenGetClose : MonoBehaviour
{
    public float distanceToDissapear = 3f;
    private Transform playerTransform;
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }
    private void Update()
    {
        if (playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= distanceToDissapear)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
