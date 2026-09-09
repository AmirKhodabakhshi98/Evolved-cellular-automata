using UnityEngine;

public class GridCamera : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] private int gridWidth = 10;
    [SerializeField] private int gridHeight = 10;
    [SerializeField] private float padding = 1f;

    void Start()
    {
        CenterOnGrid();
    }

    void Update()
    {
        CenterOnGrid();
    }
    void CenterOnGrid()
    {
        Camera cam = GetComponent<Camera>();

        float width = gridWidth;
        float height = gridHeight;

        Vector3 center = grid.transform.position +
                         new Vector3(width / 2f, height / 2f, 0);

        transform.position = new Vector3(
            center.x,
            center.y,
            transform.position.z
        );

        float requiredHeight = Mathf.Max(
            height,
            width / cam.aspect
        );

        cam.orthographicSize = requiredHeight / 2f + padding;
    }
}