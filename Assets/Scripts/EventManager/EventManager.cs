using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// EventManager script: It defines all events in the game. Singleton script.
/// </summary>
public class EventManager : MonoBehaviour
{
    #region Public Attributes

    // Singleton: Self reference.
    public static EventManager instance = null;

    // Events.
    public event Action<bool> OnPauseChanged;
    public event Action<bool> OnDiceIdle;

    #endregion

    #region Public Methods

    /// <summary>
    /// Awake: Unity Object Initialization method. Singleton addon.
    /// </summary>
    public void Awake()
    {
        // Singleton staff. Don't touch!
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnPauseChangedAction(bool pause)
    {
        if (OnPauseChanged != null) OnPauseChanged(pause);
    }

    public void OnDiceIdleAction(bool idle)
    {
        if (OnDiceIdle != null) OnDiceIdle(idle);
    }

    #endregion
}