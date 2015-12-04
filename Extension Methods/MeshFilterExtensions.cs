using UnityEngine;

public static class MeshFilterExtensions
{ 
    public static void SetVertexColor(this MeshFilter meshFilter, Color32 color)
    {
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        Color32[] colors = new Color32[vertices.Length];
        int i = 0;
        while (i < vertices.Length)
        {
            colors[i] = color;
            i++;
        }
        mesh.colors32 = colors;
    }

}
