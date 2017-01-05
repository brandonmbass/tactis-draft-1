using UnityEngine;
using System.Collections;

public static class TerrainManager
{
    public static bool GetGroundHitLocation(out RaycastHit hitInfo)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var terrainLayerMask = 1 << LayerMask.NameToLayer("Terrain");
        return Physics.Raycast(ray, out hitInfo, Mathf.Infinity, terrainLayerMask);
    }
}
