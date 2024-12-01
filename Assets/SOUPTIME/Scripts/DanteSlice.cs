using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanteSlice : MonoBehaviour
{
    public GameObject brocolli;
    public GameObject cabbage;
    public GameObject carrot;
    public GameObject onion;
    public GameObject tomato;
    public Transform spawnPoint;
    private string brocolliTag = "brocolli";
    private string cabbageTag = "cabbage";
    private string carrotTag = "carrot";
    private string onionTag = "onion";
    private string tomatoTag = "tomato";
    private void OnTriggerEnter(Collider other)
        {
            GameObject collidedObject = other.gameObject;
            Transform collidedTransform = collidedObject.transform;
            
        if (collidedObject.CompareTag(brocolliTag))
                {
                Destroy(collidedObject);
                Instantiate(brocolli, collidedObject.transform.position, collidedObject.transform.rotation);
            }
        if (collidedObject.CompareTag(cabbageTag))
        {
            Destroy(collidedObject);
            Instantiate(cabbage, collidedObject.transform.position, collidedObject.transform.rotation);
        }
        if (collidedObject.CompareTag(carrotTag))
        {
            Destroy(collidedObject);
            Instantiate(carrot, collidedObject.transform.position, collidedObject.transform.rotation);
        }
        if (collidedObject.CompareTag(onionTag))
        {
            Destroy(collidedObject);
            Instantiate(onion, collidedObject.transform.position, collidedObject.transform.rotation);
        }
        if (collidedObject.CompareTag(tomatoTag))
        {
            Destroy(collidedObject);
            Instantiate(tomato, collidedObject.transform.position, collidedObject.transform.rotation);
        }
    }
}
