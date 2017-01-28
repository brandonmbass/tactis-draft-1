using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enterable : Interactable
{
    public string SceneName;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Interact()
    {
        Debug.Log("Interacting (enterable)");
        SceneManager.LoadScene(SceneName);
    }
}
