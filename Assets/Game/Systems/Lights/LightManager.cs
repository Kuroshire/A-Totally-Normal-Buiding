using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] Light[] lights;
    [SerializeField] private bool startingState;

    private bool currentState;
    public bool CurrentState => currentState;

    private void Start()
    {
        SetLights(startingState);
        currentState = startingState;
    }

    public void SetLights(bool state)
    {
        foreach (Light light in lights)
        {
            light.enabled = state;
        }

        currentState = state;
    }
}
