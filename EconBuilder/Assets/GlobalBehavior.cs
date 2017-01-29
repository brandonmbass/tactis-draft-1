using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalBehavior : MonoBehaviour {

    protected BuildingManager BuildingManager { get { return Get<BuildingManager>(); } }
    protected UIManager UIManager { get { return Get<UIManager>(); } }
    protected UserActionManager UserActionManager { get { return Get<UserActionManager>(); } }
    protected ResourceManager ResourceManager { get { return Get<ResourceManager>(); } }
    protected ChatManager ChatManager { get { return Get<ChatManager>(); } }
    protected InputManager InputManager { get { return Get<InputManager>(); } }
    protected Character Character { get { return GameObject.Find("Character").GetComponent<Character>(); } }
    protected DialogManager DialogManager { get { return Get<DialogManager>(); } }

    private T Get<T>()
    {
        return GetComponent<T>();
    }
}
