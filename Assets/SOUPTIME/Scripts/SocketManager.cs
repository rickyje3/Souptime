using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SocketManager : MonoBehaviour
{
    public List<Socket> sockets; // List of socket references
    public Cheese cheeseScript;
    public UnityEvent allSocketsFilled; // Event to trigger when all sockets are filled

    private void Start()
    {
        CheckIfFull();
        
    }

    public void CheckIfFull()
    {
        if (AreAllSocketsFilled())
        {
            cheeseScript.isSocketed = true;
            foreach (Socket socket in sockets)
            {
                socket.Empty();
            }
        }
    }
private bool AreAllSocketsFilled()
    {
        foreach (Socket socket in sockets)
        {
            if (!socket.IsFilled())
            {
                return false;
            }
        }
        return true;
    }
}