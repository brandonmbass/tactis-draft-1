using UnityEngine;
using System.Collections;
using System;

public class BuildingManager : GlobalBehavior {

    public GameObject SelectedBuilding;

    public bool isPlacing = false;
    GameObject m_Building;

    // Use this for initialization
    void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update()
    {
	}    

    void PlaceHouse()
    {
        m_Building.GetComponent<BuildingPlacement>().ExitBuildingPlacement();
        m_Building = null;
        isPlacing = false;
    }
    
    public void StartPlacingHouse()
    {        
        RaycastHit hitInfo;
        if(TerrainManager.GetGroundHitLocation(out hitInfo))
        { 
            // TODO: better rotation
            m_Building = (GameObject)Instantiate(SelectedBuilding, hitInfo.point, transform.rotation);
            m_Building.GetComponent<BuildingPlacement>().enabled = true;
            isPlacing = true;

            // Prevent input handling when placing
            InputManager.KeyPressed.AddListener((args) =>
            {
                if (args.IsPressed(KeyCode.Escape) || Input.GetMouseButtonDown(1))
                {
                    StopPlacingHouse();
                    return args.RemoveKeys(KeyCode.Escape).RemoveSelf();
                }
                else if (m_Building != null && Input.GetMouseButtonDown(0) && m_Building.GetComponent<BuildingPlacement>().IsValidLocation())
                {
                    PlaceHouse();
                    return args.RemoveSelf();
                }

                return args;
            });
        }
    }

    void StopPlacingHouse()
    {
        m_Building.GetComponent<BuildingPlacement>().ExitBuildingPlacement();
        isPlacing = false;
        Destroy(m_Building);
        m_Building = null;
    }    

    
}