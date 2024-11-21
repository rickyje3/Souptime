using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseGrating : MonoBehaviour
{
    public GameObject prefabToSpawn;
    //public Transform spawnPoint;
    private int cutCount = 0;
    public int maxCutCount = 3;
    private GameObject cheeseToCut;
    [SerializeField] private string targetLayer = "Cheese";
    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;
        cheeseToCut = collidedObject;
        Transform collidedTransform = collidedObject.transform;
        if (collidedObject.layer == LayerMask.NameToLayer("Cheese"))
        {
            Debug.Log($"Collided with {collidedObject.name}, which has the layer: {targetLayer}");
            cutCount++;
            Debug.Log("Cut Count is: " + cutCount);
            Vector3 spawnPosition = other.transform.position;
            Quaternion spawnRotation = other.transform.rotation;
            Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            if (cutCount == maxCutCount)
            {
                cutCount = 0;
                Destroy(cheeseToCut);
                StartCoroutine(DelayedAction());
            }
            
        }
        else
        {
            Debug.Log($"Triggered by object without the layer: {targetLayer}");
        }
    }

    IEnumerator DelayedAction()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Code to execute after the delay
        Debug.Log("1 second delay is over!");
    }
}
