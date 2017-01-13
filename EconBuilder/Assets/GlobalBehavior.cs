using UnityEngine;
using System.Collections;

public class GlobalBehavior : MonoBehaviour {

    protected BuildingManager BuildingManager;
    protected UIManager UIManager;
    protected UserActionManager UserActionManager;
    protected ResourceManager ResourceManager;
    protected ChatManager ChatManager;
    protected InputManager InputManager;
    protected Character Character;

    protected void Init () {
        BuildingManager = GetComponent<BuildingManager>();
        UIManager = GetComponent<UIManager>();
        UserActionManager = GetComponent<UserActionManager>();
        ResourceManager = GetComponent<ResourceManager>();
        ChatManager = GetComponent<ChatManager>();
        InputManager = GetComponent<InputManager>();
        Character = GameObject.Find("Character").GetComponent<Character>();
    }	
}
