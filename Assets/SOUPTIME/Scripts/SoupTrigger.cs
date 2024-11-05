using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupTrigger : MonoBehaviour
{
    //the soup object (should be a child object of the bowl)
    public GameObject soupInBowl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoupVat"))
        {
            if (soupInBowl != null)
            {
                soupInBowl.SetActive(true);
            }
        }

        if (other.CompareTag("Ground"))
        {
            if (soupInBowl.activeInHierarchy == true)
            {
                soupInBowl.SetActive(false);
            }
        }
    }
}

