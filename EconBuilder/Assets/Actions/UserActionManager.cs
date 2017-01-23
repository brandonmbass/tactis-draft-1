using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserActionManager : MonoBehaviour {
    public GameObject _character;
    public float _globalCooldown = 1.0f;
    private float _globalLastActionTime;

    public Chop _chop;
    public Interact _interact;
    ResourceManager resourceManager;
    UIManager uiManager;
    
    void Start() {
        resourceManager = GetComponent<ResourceManager>();
        uiManager = GetComponent<UIManager>();
        _globalLastActionTime = Time.time;

        _chop = new Chop(_character, 1, new TargettingArc(70f, 10f) );
        _interact = new Interact(_character, new TargettingArc(50f, 10f) );
    }
	public void Chop()
    {
        Execute(_chop);
    }
    public void Interact()
    {
        Execute(_interact);
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

        if (action.HasValidTarget())
        {
            action.Execute();
            notifyGlobalAction();
            Debug.Log(action.GetType().Name + " executed");
        }
        else
        {
            Debug.Log("nothing to " + action.GetType().Name);
        }

        action.Execute();
    }
    
    public bool IsGlobalOnCooldown()
    {
        return (Time.time - _globalLastActionTime) <= _globalCooldown;
    }

    public void notifyGlobalAction()
    {
        _globalLastActionTime = Time.time;
    }
}
