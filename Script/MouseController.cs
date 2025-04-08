using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private GameObject playerTransform;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LineRenderer lineRenderer;

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
