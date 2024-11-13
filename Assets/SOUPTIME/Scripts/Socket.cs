using UnityEngine;

public class Socket : MonoBehaviour
{
    private bool isFilled;

    public void Fill()
    {
        isFilled = true;
    }

    public void Empty()
    {
        isFilled = false;
    }

    public bool IsFilled()
    {
        return isFilled;
    }
    private void OnTriggerEnter(Collider other)
    {
        
            Fill();
            Destroy(other.gameObject); // Or another action
        }
    
}