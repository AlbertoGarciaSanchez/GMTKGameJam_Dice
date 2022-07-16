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

    /// <summary>
    /// TransitionMainMenuAction: Event to perform the transition to main menu. 
    /// </summary>
    public void OnPauseChangedAction(bool pause)
    {
        if (OnPauseChanged != null) OnPauseChanged(pause);
    }

    #endregion
}