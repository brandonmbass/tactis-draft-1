using UnityEngine;
using System.Collections;

public class TurnManager : GlobalBehavior
{
    public float turnDuration = 60.0f;
    float currentTime = 0.0f;

	void Start() {
        Init();
    }
	
	void Update() {
        currentTime += Time.deltaTime;
        if (currentTime > turnDuration)
        {
            NewTurn();
        }
        UIManager.SetSundial(currentTime/turnDuration);
    }

    void NewTurn()
    {
        currentTime = 0;
    }
}
