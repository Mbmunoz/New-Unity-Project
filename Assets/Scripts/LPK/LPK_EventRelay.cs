﻿/***************************************************
File:           LPK_EventRelay.cs
Authors:        Christopher Onorati
Last Updated:   2/28/19
Last Version:   2018.3.4
Description:
  This component can be used to relay on events to other
  objects and components.

This script is a basic and generic implementation of its 
functionality. It is designed for educational purposes and 
aimed at helping beginners.

Copyright 2018-2019, DigiPen Institute of Technology
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* CLASS NAME  : LPK_EventRelay
* DESCRIPTION : Component to relay events to unrelated components.
**/
public class LPK_EventRelay : LPK_LogicBase
{
    /************************************************************************************/

    [Header("Component Properties")]

    [Tooltip("Events to arbitarily relay off when triggered.")]
    public LPK_EventList m_RelayedEvents = new LPK_EventList();

    [Header("Event Receiving Info")]

    [Tooltip("Which event will trigger this component's action")]
    public LPK_EventList m_EventTrigger = new LPK_EventList();

    [Header("Event Sending Info")]

    [Tooltip("Receiver Game Objects for relayed events.")]
    public LPK_EventReceivers m_RelayedEventReceivers;

    /**
    * FUNCTION NAME: OnStart
    * DESCRIPTION  : Sets up what event to listen to for event dispatching.
    * INPUTS       : None
    * OUTPUTS      : None
    **/
    override protected void OnStart()
    {
        InitializeEvent(m_EventTrigger, OnEvent);
    }

    /**
    * FUNCTION NAME: OnEvent
    * DESCRIPTION  : Event responding.
    * INPUTS       : data - Event data to parse for validation.
    * OUTPUTS      : None
    **/
    protected override void OnEvent(LPK_EventManager.LPK_EventData data)
    {
        //Event validation.
        if (!ShouldRespondToEvent(data))
            return;

        //Dispatch events here.
        LPK_EventManager.LPK_EventData sendData = new LPK_EventManager.LPK_EventData(gameObject, m_RelayedEventReceivers);
        LPK_EventManager.InvokeEvent(m_RelayedEvents, sendData);
    }
}
