using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlTrigger : MonoBehaviour
{
    public GameObject bowlLiquid;
    public GameObject potLiquid;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            if (potLiquid != null)
            {
                potLiquid.SetActive(false);
            }

            if (bowlLiquid != null)
            {
                bowlLiquid.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pot"))
        {
            if (bowlLiquid != null)
            {
                bowlLiquid.SetActive(false);
            }

            if (potLiquid != null)
            {
                potLiquid.SetActive(true);
            }
        }
    }
}
