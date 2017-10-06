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
    protected Mobile CurrentCharacter { get { return GameObject.Find("CurrentCharacter").GetComponent<Mobile>(); } }
    protected DialogManager DialogManager { get { return Get<DialogManager>(); } }
    protected StoreManager StoreManager { get { return Get<StoreManager>(); } }
    protected QuestManager QuestManager { get { return Get<QuestManager>(); } }
    protected CraftingManager CraftingManager { get { return Get<CraftingManager>(); } }

    private T Get<T>()
    {
        return GetComponent<T>();
    }
}
