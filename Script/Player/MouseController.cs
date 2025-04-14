using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Color lineColor = Color.cyan;
    [SerializeField] private float maxDistance = 15f;
    
    private Camera mainCamera;
    private readonly Vector3[] positions = new Vector3[2];
    private bool isActive;

    void Awake()
    {
        mainCamera = Camera.main;
        
        if (isActive && lineRenderer != null)
        {
            lineRenderer.startColor = lineRenderer.endColor = lineColor;
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;    
        }
    }

    void Update()
    {
        if (!isActive || mainCamera == null || lineRenderer == null)
            return;
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        lineRenderer.enabled = Physics.Raycast(ray, out RaycastHit hit, maxDistance, groundLayer);
        
        if (lineRenderer.enabled)
        {
            positions[0] = transform.position;
            positions[1] = hit.point;
            lineRenderer.SetPositions(positions);
        }
    }

    public void SetActive(bool active)
    {
        isActive = active;
        if (!isActive && lineRenderer != null)
            lineRenderer.enabled = false;
    }
}