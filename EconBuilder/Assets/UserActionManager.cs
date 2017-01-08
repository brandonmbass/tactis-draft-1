﻿using UnityEngine;
using System.Collections;

public class UserActionManager : MonoBehaviour {
    public GameObject character;
    public int chopRadius = 10;

    ResourceManager resourceManager;
    UIManager uiManager;

    void Start () {
        resourceManager = GetComponent<ResourceManager>();
        uiManager = GetComponent<UIManager>();
	}
	
	void Update () {
	
	}
    
    public void Chop()
    {
        var nearestObject = GetNearest(chopRadius);
        if (nearestObject == null)
        {
            Debug.Log("Nothing to chop!");
            return;
        }

        // Artificially 'Click' the appropriate action key
        uiManager.Click();

        var choppable = nearestObject.GetComponent<Choppable>();
        choppable.Life--;
        Debug.Log("Chop.");

        if (choppable.Life <= 0)
        {
            nearestObject.SetActive(false);
            // TODO: change ResourceType to a base class, then have the resources directly in the Choppable interface
            resourceManager.AddResource(ResourceType.Wood, choppable.Value);
        }
    }

    // TODO: move to character singleton or something like that
    public GameObject GetNearest(int radius)
    {
        var colliders = Physics.OverlapSphere(character.transform.position, radius);

        float minDist = Mathf.Infinity;
        GameObject nearestObject = null;
        foreach (var collider in colliders)
        {
            var choppable = collider.gameObject.GetComponent<Choppable>();
            if (choppable == null)
            {
                continue;
            }

            var closestPoint = collider.ClosestPointOnBounds(character.transform.position);
            var dist = Vector3.Distance(closestPoint, character.transform.position);
            if (dist < minDist)
            {
                nearestObject = collider.gameObject;
                minDist = dist;
            }
        }

        return nearestObject;
    }
}
