using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEntity : MonoBehaviour
{
    public bool pauseStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.OnPauseChanged += pauseChanged;
    }

    public bool CheckPauseStatus()
    {
        return pauseStatus;
    }

    public virtual void pauseChanged(bool newPause){
        pauseStatus = newPause;
    }
}
