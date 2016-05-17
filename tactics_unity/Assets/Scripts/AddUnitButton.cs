using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddUnitButton : MonoBehaviour {

    public Button Button;
    public BattlefieldController BattlefieldController;

	// Use this for initialization
	void Start () {
        Button.onClick.AddListener(() => { BattlefieldController.PushState<UnitAdderState>(); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
