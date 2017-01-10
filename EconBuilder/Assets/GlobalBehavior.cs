using UnityEngine;
using System.Collections;

public class GlobalBehavior : MonoBehaviour {

    protected BuildingManager buildingManager;
    protected UIManager uiManager;
    protected UserActionManager userActionManager;
    protected ResourceManager resourceManager;

    protected void Start () {
        buildingManager = GetComponent<BuildingManager>();
        uiManager = GetComponent<UIManager>();
        userActionManager = GetComponent<UserActionManager>();
        resourceManager = GetComponent<ResourceManager>();
    }	
}
