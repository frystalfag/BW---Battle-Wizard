using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    float MouseSensitivity = 400f;
    float XRotation = 0f;
    float YRotation = 0f;
	public Transform CameraTransform;
	

    void Start()
    {
    }
    
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
            XRotation = Mathf.Clamp(XRotation, -12.0f, 60.0f);
            YRotation += MouseX;
            transform.localRotation = Quaternion.Euler(0f, YRotation, 0f);
            CameraTransform.localRotation = Quaternion.Euler(20f, 0f, XRotation);    
        }
        
    }
}
