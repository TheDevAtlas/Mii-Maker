using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MiiBody : MonoBehaviour
{
    public Slider heightSlider;  // Slider to control height
    public Slider widthSlider;   // Slider to control width

    private Mesh mesh;

    private Vector3[] vertices;
    private int[] triangles;

    // Initial dimensions
    private float initialHeight = 2f;
    private float initialWidth = 1f;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Initialize sliders with lambda expressions to match the expected delegate
        heightSlider.onValueChanged.AddListener(value => UpdateMesh());
        widthSlider.onValueChanged.AddListener(value => UpdateMesh());

        // Create the initial mesh
        CreateMesh();
    }

    void CreateMesh()
    {
        // Define the vertices of a simple body shape (a box in this example)
        vertices = new Vector3[]
        {
            new Vector3(-initialWidth, 0, 0),  // Bottom-left
            new Vector3(initialWidth, 0, 0),   // Bottom-right
            new Vector3(-initialWidth, initialHeight, 0),  // Top-left
            new Vector3(initialWidth, initialHeight, 0)    // Top-right
        };

        // Define the triangles (two triangles to make a rectangle)
        triangles = new int[]
        {
            0, 2, 1,
            1, 2, 3
        };

        UpdateMesh();
    }

    void UpdateMesh()
    {
        float height = heightSlider.value;
        float width = widthSlider.value;

        // Update vertices based on the slider values
        vertices[0] = new Vector3(-width, 0, 0);  // Bottom-left
        vertices[1] = new Vector3(width, 0, 0);   // Bottom-right
        vertices[2] = new Vector3(-width, height, 0);  // Top-left
        vertices[3] = new Vector3(width, height, 0);   // Top-right

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void OnDestroy()
    {
        // Clean up listeners
        heightSlider.onValueChanged.RemoveListener(value => UpdateMesh());
        widthSlider.onValueChanged.RemoveListener(value => UpdateMesh());
    }
}
