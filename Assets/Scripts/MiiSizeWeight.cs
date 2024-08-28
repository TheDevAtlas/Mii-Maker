using UnityEngine;

public class MiiSizeWeight : MonoBehaviour
{
    public Transform[] Bodies;
    public Transform[] Head;

    public SkinnedMeshRenderer[] meshes;
    public Mesh[] meshesBack;

    public float weight;
    public float height;

    private Vector3[][] originalVertices; // To store the original vertex positions

    void Start()
    {
        originalVertices = new Vector3[meshes.Length][];
        for (int i = 0; i < meshes.Length; i++)
        {
            // Store the original mesh and its vertices
            meshesBack[i] = meshes[i].sharedMesh;
            originalVertices[i] = meshesBack[i].vertices;
        }

        UpdateMii();
    }

    public void SetWeight(float n)
    {
        weight = n;
        UpdateMii();
    }

    public void SetHeight(float n)
    {
        height = n;
        UpdateMii();
    }

    void UpdateMii()
    {
        foreach (Transform t in Bodies)
        {
            // Scale the body based on the height
            t.localScale = Vector3.one * (height / 2f + 0.5f);
        }

        foreach (Transform t in Head)
        {
            // Reverse the scaling applied to the body to keep the head size consistent
            float inverseScale = 1f / (height / 2f + 0.5f);
            t.localScale = Vector3.one * inverseScale;
        }

        for (int i = 0; i < meshes.Length; i++)
        {
            Mesh mesh = meshesBack[i];
            Vector3[] vertices = new Vector3[originalVertices[i].Length];

            for (int j = 0; j < vertices.Length; j++)
            {
                // Calculate the scaling based on the weight, with 0.5f being the original size
                float scale = Mathf.Lerp(0.8f, 1.3f, weight);
                vertices[j] = originalVertices[i][j] * scale;
            }

            // Update the mesh with the new vertex positions
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            // Assign the modified mesh back to the SkinnedMeshRenderer
            meshes[i].sharedMesh = mesh;
        }
    }
}
