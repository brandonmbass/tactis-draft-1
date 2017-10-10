﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardData : MonoBehaviour {

    public Quest MakeArrows = new Quest {
        Title = "Make 10 arrows",
        ShortDescription = "Make 10 arrows for the city guard.",
        LongDescription = @"The city guard is underequiped! To keep the townspeople safe, they need arrows. Make them 10 arrows and you will not only help the 
townspeople, but you'll earn a decent reward as well.",
        CanComplete = () => { return true; }, // TODO: check inventory for arrows
        Complete = () => {
            
        }, // TODO: remove from inventory, set status

        // Dialog support
        ProgressQuestion = "Have you had any luck making those arrows?",
        DoneAnswer = "Yep - order complete!",
        NotDoneAnswer = "Sorry, still working on it."
    };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
