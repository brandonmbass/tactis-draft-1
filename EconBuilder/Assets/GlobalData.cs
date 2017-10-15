using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class G {
    static private GameObject managers;

    static public UIManager UIManager { get { return Get<UIManager>(); } }
    static public BuildingManager BuildingManager { get { return Get<BuildingManager>(); } }
    static public UserActionManager UserActionManager { get { return Get<UserActionManager>(); } }
    static public ResourceManager ResourceManager { get { return Get<ResourceManager>(); } }
    static public ChatManager ChatManager { get { return Get<ChatManager>(); } }
    static public InputManager InputManager { get { return Get<InputManager>(); } }
    static public DialogManager DialogManager { get { return Get<DialogManager>(); } }
    static public StoreManager StoreManager { get { return Get<StoreManager>(); } }
    static public QuestManager QuestManager { get { return Get<QuestManager>(); } }
    static public CraftingManager CraftingManager { get { return Get<CraftingManager>(); } }
    static public CurrentCharacter CurrentCharacter {  get { return Get<CurrentCharacter>("_GLOBAL_DATA_/CharacterData/CurrentCharacterData");  } }


    static private T Get<T>(string gameObject = null)
    {
        if (managers == null)
        {
            managers = GameObject.Find("_GLOBAL_DATA_/Managers");
        }

        if (gameObject == null)
        {
            return managers.GetComponent<T>();
        }

        // TODO: cache
        return GameObject.Find(gameObject).GetComponent<T>();
    }
}
