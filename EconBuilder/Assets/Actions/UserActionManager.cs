using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserActionManager : MonoBehaviour {
    public float _globalCooldown = 1.0f;
    private float _globalLastActionTime;

    public Chop _chop;
    public Interact _interact;
    ResourceManager resourceManager;
    UIManager uiManager;
    GameObject _character;
    GameObject character
    {
        get
        {
            if (_character == null || !_character.activeSelf)
                _character = GameObject.Find("CurrentCharacter");

            return _character;
        }
    }

    void Start() {
        resourceManager = GetComponent<ResourceManager>();
        uiManager = GetComponent<UIManager>();
        _globalLastActionTime = Time.time;

        _chop = new Chop(1, new TargettingArc(70f, 10f) );
        _interact = new Interact(new TargettingArc(50f, 10f) );
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

    public void Execute(IAction action)
    {
        if (IsGlobalOnCooldown())
        {
            return;
        }

        if (action.HasValidTarget(character))
        {
            action.Execute(character);
            notifyGlobalAction();
            Debug.Log(action.GetType().Name + " executed");
        }
        else
        {
            Debug.Log("nothing to " + action.GetType().Name);
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
