using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SocketManager : MonoBehaviour
{
    public List<Socket> sockets; // List of socket references
    public Cheese cheeseScript;
    public UnityEvent allSocketsFilled; // Event to trigger when all sockets are filled

    private void Update()
    {
        if (AreAllSocketsFilled())
        {
            cheeseScript.isSocketed = true;
            //allSocketsFilled.Invoke();
            // Optionally, you might want to disable this check after the event has been invoked
            // or reset the sockets.
            //enabled = false; // Disable this script after event is triggered
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