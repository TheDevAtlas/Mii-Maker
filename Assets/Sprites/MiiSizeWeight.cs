using UnityEngine;

public class MiiSizeWeight : MonoBehaviour
{
    public SkinnedMeshRenderer[] BodyMeshes;
    public Transform[] Head;

    public float weight;
    public float height;

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
        foreach (SkinnedMeshRenderer smr in BodyMeshes)
        {
            Mesh mesh = smr.sharedMesh;
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                // Inflate the mesh based on weight and height
                vertices[i] = vertices[i] * (height / 2f + 0.5f) * (1f + weight / 10f);
            }

            // Update the mesh with the new vertex positions
            mesh.vertices = vertices;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            // Assign the modified mesh back to the SkinnedMeshRenderer
            smr.sharedMesh = mesh;
        }

        // Reverse the scaling applied to the body to keep the head size consistent
        foreach (Transform t in Head)
        {
            float inverseScale = 1f / (height / 2f + 0.5f);
            t.localScale = Vector3.one * inverseScale;
        }
    }
}
