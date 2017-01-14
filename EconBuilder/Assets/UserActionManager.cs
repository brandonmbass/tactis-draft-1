using UnityEngine;
using System.Collections;

public class UserActionManager : MonoBehaviour {
    public GameObject character;
    public int chopRadius = 10;
    public int interactRadius = 10;
    public float globalCooldown = 1.0f;
    private float globalLastActionTime;

    ResourceManager resourceManager;
    UIManager uiManager;
    

    void Start () {
        resourceManager = GetComponent<ResourceManager>();
        uiManager = GetComponent<UIManager>();
        globalLastActionTime = Time.time;
    }
	
	void Update () {
	}

    void FixedUpdate()
    {
        
    }
    
    //TODO make this depend on tools? better worse tools, radius, chopping amount?
    public void Chop()
    {
        if (IsGlobalOnCooldown())
        {
            return;
        }

        var nearestObject = GetNearest<Choppable>(chopRadius);
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
        return (Time.time - globalLastActionTime) <= globalCooldown;
    }

    public void notifyGlobalAction()
    {
        globalLastActionTime = Time.time;
    }
    // TODO: move to character singleton or something like that
    // TODO: better targetting, perhaps facing?
    public GameObject GetNearest<T>(int radius)
    {
        var colliders = Physics.OverlapSphere(character.transform.position, radius);

        float minDist = Mathf.Infinity;
        GameObject nearestObject = null;
        foreach (var collider in colliders)
        {
            var choppable = collider.gameObject.GetComponent<T>();
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
