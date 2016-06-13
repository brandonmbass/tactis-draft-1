using UnityEngine;
using System.Collections;
using UnityEditor;

public class BattlefieldGenerator : EditorWindow {
    public Battlefield battlefield;

    public int width;
    public int depth;
    public float scale;
    public float frequency;

    public Material tileMaterial;
    public Surface baseSurface;
    
    [MenuItem( "Window/Battlefield Editor..." )]
    private static void showEditor()
    {
        EditorWindow.GetWindow<BattlefieldGenerator>(false, "Battlfield Generator");
    } 

    private static bool showEditorValidator()
    {
        return true;
    }

    void OnGUI(){
        GUILayout.Label(" Generator", EditorStyles.boldLabel);
        width = EditorGUILayout.IntField("Width", width);
        depth = EditorGUILayout.IntField("Depth", depth);
        scale = EditorGUILayout.FloatField("Scale", scale);
        frequency = EditorGUILayout.FloatField("Frequency", frequency);
        baseSurface = EditorGUILayout.ObjectField("Surface", baseSurface, typeof(Surface), false, null) as Surface;
        tileMaterial = EditorGUILayout.ObjectField("Tile Material", tileMaterial, typeof(Material), false, null) as Material;

        if (GUILayout.Button("Generate"))
            generateBattlefield(width, depth, scale, frequency);
    }

    public void generateBattlefield(int width, int depth, float scale, float frequency)
    {
        GameObject existing = GameObject.Find("Battlefield");
        if(existing)
            DestroyImmediate(existing);

        GameObject base_object = new GameObject("Battlefield");
        base_object.AddComponent<Battlefield>();
        base_object.AddComponent<BattlefieldController>();

        battlefield = base_object.GetComponent<Battlefield>();

        BattlefieldController bfc = battlefield.GetComponent<BattlefieldController>();
        bfc.Battlefield = battlefield;

        battlefield.init(width, depth, baseSurface, tileMaterial);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < depth; y++)
            {
                float height = scale * Mathf.PerlinNoise(x / frequency, y / frequency);
                battlefield.createSurface(x, y, height);
                battlefield.createBox(x, y, height);
            }
        }
    }
}
