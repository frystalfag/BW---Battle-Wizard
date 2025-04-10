using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject playerTransform;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Material arrowMaterial;
    [SerializeField] private float repeatFactor = 5f;

    void Start()
    {
        lineRenderer.material = arrowMaterial;
        lineRenderer.textureMode = LineTextureMode.Tile;
        lineRenderer.material.mainTextureScale = new Vector2(repeatFactor, 1);
        lineRenderer.startWidth = 0.8f;
        lineRenderer.endWidth = 0.8f;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 15f, groundLayer))
        {
            Vector3 StartPosition = transform.position;
            Vector3 EndPosition = hit.point;
            lineRenderer.SetPosition(0, StartPosition);
            lineRenderer.SetPosition(1, EndPosition);
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
    
}
