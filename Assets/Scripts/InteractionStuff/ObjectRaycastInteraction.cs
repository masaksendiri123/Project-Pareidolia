using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectRaycastInteraction : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject PressEToInteractUI;

    public InputActionReference InteractingAction;

    [Header("Raycast Settings")]
    public float RaycastRange = 100f;

    private Ray m_ray;
    private RaycastHit m_raycastHit;
    private RaycastHit m_raycastHitInteract;

    private void Awake()
    {
        InteractingAction.action.performed += InteractWithObject;
    }

    private void OnDestroy()
    {
        InteractingAction.action.performed -= InteractWithObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(m_ray, out m_raycastHit, RaycastRange))
        {
            if (m_raycastHit.collider.CompareTag("Interactable"))
            {
                PressEToInteractUI.SetActive(true);
            }
            else
            {
                PressEToInteractUI.SetActive(false);
            }
        }
    }

    void InteractWithObject(InputAction.CallbackContext context)
    {
        m_ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(m_ray, out m_raycastHitInteract, RaycastRange))
        {
            if (m_raycastHitInteract.collider.CompareTag("Interactable"))
            {
                if (m_raycastHitInteract.collider.GetComponent<OpenUIForDialogAndNote>())
                {
                    m_raycastHitInteract.collider.GetComponent<OpenUIForDialogAndNote>().OnInteract();
                }
                if (m_raycastHitInteract.collider.GetComponent<TakingEvidenceItem>())
                {
                    m_raycastHitInteract.collider.GetComponent<TakingEvidenceItem>().OnInteract();
                }
            }
        }
    }
}
