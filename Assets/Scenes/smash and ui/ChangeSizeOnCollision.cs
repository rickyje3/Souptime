using UnityEngine;

public class ChangeSizeOnCollision : MonoBehaviour
{
    public GameObject targetObject; //mallet

    public Vector3 newSize = new Vector3(2f, 2f, 2f);

    private Vector3 originalSize;

    void Start()
    {
        originalSize = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetObject)
        {
            transform.localScale = newSize;
        }
    }


}