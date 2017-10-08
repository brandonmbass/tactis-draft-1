using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable{

    public string container_id;
    override public void Interact()
    {
        var data = GameObject.Find("_GLOBAL_DATA_/" + container_id);
        var contents = data.GetComponent<Inventory>();
        //var playerInventory = GameObject.Find("_GLOBAL_DATA_/CharacterData/CurrentCharacter").GetComponent<Inventory>();
    }
}
