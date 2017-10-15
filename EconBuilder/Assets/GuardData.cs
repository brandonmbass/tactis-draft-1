using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardData : MonoBehaviour {

    public Quest MakeArrows;

	// Use this for initialization
	void Start () {
        MakeArrows = new Quest
        {
            Title = "Make 10 arrows",
            ShortDescription = "Make 10 arrows for the city guard.",
            LongDescription = @"The city guard is underequiped! To keep the townspeople safe, they need arrows. Make them 10 arrows and you will not only help the 
townspeople, but you'll earn a decent reward as well.",
            CanComplete = () => { return G.CurrentCharacter.Inventory.Has(10, Items.Arrow); },
            Complete = () => {
                G.CurrentCharacter.Inventory.Remove(10, Items.Arrow);
                G.CurrentCharacter.Inventory.Add(200, ResourceType.Gold);
                MakeArrows.Status = QuestStatus.Completed;
            }, // TODO: remove from inventory, set status

            // Dialog support
            ProgressQuestion = "Have you had any luck making those arrows?",
            DoneAnswer = "Yep - order complete!",
            NotDoneAnswer = "Sorry, still working on it."
        };
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
