using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopObjectController : MonoBehaviour
{
    public bool IsStopped {get; private set;}

    public void Stop()
    {
        IsStopped = true;
    }

    public void UnStop()
    {
        IsStopped = false;
    }
}
