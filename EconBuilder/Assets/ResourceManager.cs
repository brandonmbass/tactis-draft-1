using UnityEngine;
using System.Collections;
using System;

public enum ResourceType
{
    Wood,
    Ore,
    Gold,
}

public class ResourceManager : GlobalBehavior {

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void AddResource(ResourceType resourceType, int value)
    {
        // TODO:
        Debug.Log(string.Format("Adding {0} of resource '{1}'", value, resourceType));
    }
}
