using System;
using UnityEngine;

[Serializable]
public class CameraSettings
{
    public Camera mainCamera;

    [Space(5)] 
    [SerializeField] public Vector3 freeWH = new Vector2(2f,2f);

}

public class camera_contoller : MonoBehaviour
{
    [SerializeField]
    private CameraSettings settings = new CameraSettings();
    
    private void Awake()
    {
        if (settings.mainCamera == null)
        {
            settings.mainCamera = Camera.current;
            Debug.Log($"Camera was selected to current camera");
        }
        
    }

    private void CameraMove(Transform target)
    {
        if (settings.mainCamera.transform.position.x + settings.freeWH.x < target.position.x)
        {
            settings.mainCamera.transform.Translate(new Vector3(target.position.x-(settings.mainCamera.transform.position.x + settings.freeWH.x), 0f, 0f));
        } else if (settings.mainCamera.transform.position.x - settings.freeWH.x > target.position.x)
        {
            settings.mainCamera.transform.Translate(new Vector3(-(settings.mainCamera.transform.position.x - settings.freeWH.x - target.position.x), 0f, 0f));
        }
        
        if (settings.mainCamera.transform.position.y + settings.freeWH.y < target.position.y)
        {
            settings.mainCamera.transform.Translate(new Vector3(0f, target.position.y - (settings.mainCamera.transform.position.y + settings.freeWH.y), 0f));
        } else if (settings.mainCamera.transform.position.y - settings.freeWH.y > target.position.y)
        {
            settings.mainCamera.transform.Translate(new Vector3(0f, -(settings.mainCamera.transform.position.y - settings.freeWH.y - target.position.y), 0f));        }
        
    }
    
    private void FixedUpdate()
    {
        CameraMove(gameObject.transform);
    }

}
