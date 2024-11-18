using UnityEngine;

public class ChangeSizeOnCollision : MonoBehaviour
{
    public Vector3 newSize = new Vector3(2, 2, 2); // The size to change to
    public bool resetSizeOnExit = false;
    private Vector3 originalSize;

    void Start()
    {
        // Store the original size of the object
        originalSize = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Change size when a collision occurs
        transform.localScale = newSize;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.localScale = newSize;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Optional: Reset the size when the objects separate
        if (resetSizeOnExit)
        {
            transform.localScale = originalSize;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            transform.localScale = originalSize;
        }
    }
}
