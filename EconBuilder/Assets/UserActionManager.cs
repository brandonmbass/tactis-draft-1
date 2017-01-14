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

        _chop = new Chop(_character, 10, new TargettingArc(20f, 10f) );
        _interact = new Interact(_character, new TargettingArc(20f, 10f) );
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

        action.Execute();
    }

    public void Chop()
    {
        if(_chop.HasValidTarget())
        {
            Execute(_chop);
            notifyGlobalAction();
            Debug.Log("chop!");
        } else {
            Debug.Log("nothing to chop");
        }
    }

    
    public void Interact()
    {
        if (_interact.HasValidTarget())
        {
            Execute(_interact);
            notifyGlobalAction();
            Debug.Log("interact!");
        }
        else
        {
            Debug.Log("nothing to chop");
        }
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
