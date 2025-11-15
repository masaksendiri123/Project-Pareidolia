using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobSpeed = 14f;
    public float bobAmount = 0.05f;

    private float defaultYPos;
    private float timer;
    private Transform playerTransform;
    private Vector3 lastPosition;
    private float velocityThreshold = 0.15f;

    void Start()
    {
        defaultYPos = transform.localPosition.y;
        playerTransform = GetComponentInParent<Transform>();
        lastPosition = playerTransform.position;
    }

    void Update()
    {
        Vector3 velocity = (playerTransform.position - lastPosition) / Time.deltaTime;
        lastPosition = playerTransform.position;

        float speed = new Vector3(velocity.x, 0, velocity.z).magnitude;

        if (speed > velocityThreshold)
        {
            timer += Time.deltaTime * bobSpeed;
            float newY = defaultYPos + Mathf.Sin(timer) * bobAmount;
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        else
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultYPos, transform.localPosition.z);
        }
    }
}
