using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCharacter : EconBehavior {    

    public Mobile Mobile { get { return Get<Mobile>("CurrentCharacter"); } }
    public Inventory Inventory { get { return Get<Inventory>(); } }
    public QuestData QuestData { get { return Get<QuestData>(); } }
}
