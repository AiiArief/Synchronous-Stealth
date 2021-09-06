using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager: MonoBehaviour
{
    [SerializeField] Event m_onLoadLevelEvent;

    public List<Event> events { get; private set; } = new List<Event>();

    public void SetupEventsOnLevelStart()
    {
        _AssignAllEvents();

        m_onLoadLevelEvent.EventOnLoadLevel();
        // setup all event & load from profile??
    }

    private void _AssignAllEvents()
    {
        foreach(Transform child in transform)
        {
            Event eventChild = child.GetComponent<Event>();
            if(eventChild)
            {
                events.Add(eventChild);
            }
        }
    }
}
