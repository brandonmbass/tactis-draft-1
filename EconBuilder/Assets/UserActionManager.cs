using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserActionManager : MonoBehaviour {
    public int _chopRadius = 10;
    public int _interactRadius = 10;
    public GameObject _character;
    public int _chopRadius = 10;
    public float _globalCooldown = 1.0f;
    private float _globalLastActionTime;

    ResourceManager resourceManager;
    UIManager uiManager;
    

    void Start() {
        resourceManager = GetComponent<ResourceManager>();
        uiManager = GetComponent<UIManager>();
        _globalLastActionTime = Time.time;
    }
	
	void Update()
    {

	}

    void FixedUpdate()
    {
        
    }

    public void Execute(iAction action)
    {
        if (IsGlobalOnCooldown())
        {
            return;
        }
        
        if(action.GetValidTarget())
        {
            action.Execute();
        }
    }
    
    //TODO make this depend on tools? better worse tools, radius, chopping amount?
    public void Chop()
    {
        // Artificially 'Click' the appropriate action key
        uiManager.Click();

        var choppable = nearestObject.GetComponent<Choppable>();
        choppable.Life--;
        Debug.Log("Chop.");
        notifyGlobalAction();

        if (choppable.Life <= 0)
        {
            nearestObject.SetActive(false);
            // TODO: change ResourceType to a base class, then have the resources directly in the Choppable interface
            resourceManager.AddResource(ResourceType.Wood, choppable.Value);
        }
    }

    public void Interact()
    {
        if (IsGlobalOnCooldown())
        {
            return;
        }

        var nearestObject = GetNearest<Interactable>(interactRadius);
        if (nearestObject == null)
        {
            Debug.Log("Nothing to interact!");
            return;
        }

        var interactable = nearestObject.GetComponent<Interactable>();
        Debug.Log("Interact.");
        interactable.Interact();
        notifyGlobalAction();
    }

    public bool IsGlobalOnCooldown()
    {
        return (Time.time - _globalLastActionTime) <= _globalCooldown;
    }

    public void notifyGlobalAction()
    {
        _globalLastActionTime = Time.time;
    }
    // TODO: move to character singleton or something like that
}
