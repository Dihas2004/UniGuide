using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;

    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    

    

    private bool lineToggle = false;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;

    }

    private void Update()
    {
        if ((lineToggle && targetPosition!=Vector3.zero))
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);

        }
        
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        for (int i = 0; i < navigationTargetObjects.Count; i++)
        {
            if (navigationTargetObjects[i].Name != name)
            {
                Renderer objectRenderer = navigationTargetObjects[i].PositionObject.GetComponent<Renderer>();
                objectRenderer.enabled = true;

            }
        }
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
        if (currentTarget!=null)
        {
            targetPosition = currentTarget.PositionObject.transform.position;
            OtherTargetsInvisible(selectedText);
        }
    }

    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }
    private void OtherTargetsInvisible(string name)
    {
        for (int i = 0; i < navigationTargetObjects.Count; i++)
        {
            if (navigationTargetObjects[i].Name != name)
            {
                Renderer objectRenderer = navigationTargetObjects[i].PositionObject.GetComponent<Renderer>();
                objectRenderer.enabled = false;

            }
        }
    }

}
