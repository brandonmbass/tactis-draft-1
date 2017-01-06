using UnityEngine;
using System.Collections;

// Handles colorization, etc for buildings during placement phase
public class BuildingPlacement : MonoBehaviour {

    public readonly Color DefaultColor = new Color(.5f, .5f, .5f, 1f);
    public readonly Color ValidSpotColor = new Color(.5f, 2f, .5f, .3f);
    public readonly Color InvalidSpotColor = new Color(2f, .5f, .5f, .3f);

    LayerMask contructLayerMask;
    bool isColliding;
    
    void Start()
    {
        contructLayerMask = 1 << LayerMask.NameToLayer("Construct");
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

    void FixedUpdate()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider collider)
    {        
        if (collider.gameObject.layer == LayerMask.NameToLayer("Construct") ||
            collider.gameObject.name == "Character")
        {
            isColliding = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        OnTriggerEnter(collider);
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hitInfo;
        var validLocation = false;
        if(TerrainManager.GetGroundHitLocation(out hitInfo))
        {
            gameObject.transform.position = hitInfo.point;
            validLocation = IsValidLocation();
        }

        foreach (var r in gameObject.GetComponentsRecursive<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Transparent);
            r.material.color = validLocation ? ValidSpotColor : InvalidSpotColor;
        }
    }
    
    // Should not be called from before Update() in messaging order
    public bool IsValidLocation()
    {
        return !isColliding;
    }

    public void ExitBuildingPlacement()
    {
        foreach (var r in gameObject.GetComponentsRecursive<MeshRenderer>())
        {
            StandardShaderUtils.ChangeRenderMode(r.material, StandardShaderUtils.BlendMode.Opaque);
            r.material.color = DefaultColor;
        }

        gameObject.GetComponent<Collider>().isTrigger = false;
        enabled = false;
    }
}


public static class StandardShaderUtils
{
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }
    }
}