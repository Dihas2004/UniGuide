using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(requiredComponent: typeof(ARRaycastManager),
    requiredComponent2: typeof(ARRaycastManager))]
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefab;
    GameObject obj;

    public ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

<<<<<<< HEAD:Assets/Scripts/ObjectPlacement.cs
    bool isObjectCreated = false;

    // Start is called before the first frame update
=======
>>>>>>> parent of a074a4d (Placing a 3D sample ground floor instead of a cube.):Assets/Scripts/NewBehaviourScript.cs
    private void Awake()
    {
        ARRaycastManager raycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

    }
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;

    }
    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;

    }
    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
<<<<<<< HEAD:Assets/Scripts/ObjectPlacement.cs
                if (isObjectCreated == false)
                {

                    obj = Instantiate(prefab, pose.position, pose.rotation);
                    isObjectCreated = true;
                }
                else
                {
                    obj.transform.position = pose.position;
                }

=======
                GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
                if (aRPlaneManager.GetPlane(hit.trackableId).alignment == PlaneAlignment.HorizontalUp)
                {
                    Vector3 position = obj.transform.position;
                    position.y = 0f;
                    Vector3 cameraPosition = Camera.main.transform.position;
                    Vector3 direction = cameraPosition - position;
                    Quaternion targetRoration = Quaternion.LookRotation(direction);
                    obj.transform.rotation = targetRoration;
                }
>>>>>>> parent of a074a4d (Placing a 3D sample ground floor instead of a cube.):Assets/Scripts/NewBehaviourScript.cs
            }

        }



    }
}