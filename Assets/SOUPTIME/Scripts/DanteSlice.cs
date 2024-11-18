using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanteSlice : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    [SerializeField] private string targetTag = "Food";
        private void OnTriggerEnter(Collider other)
        {
            GameObject collidedObject = other.gameObject;
            if (collidedObject.CompareTag(targetTag))
            {
                Debug.Log($"Collided with {collidedObject.name}, which has the tag: {targetTag}");
                Destroy(collidedObject);
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.Log($"Triggered by object with tag: {other.tag}, which is not {targetTag}");
            }
        }
}
