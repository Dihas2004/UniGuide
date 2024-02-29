using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections.Generic;

public class PathArrowVisualisation : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown targetDropdown;
    [SerializeField]
    private List<Target> targetObjects = new List<Target>();
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float moveOnDistance;

    private NavMeshPath path ;
    private float currentDistance;
    private Vector3[] pathOffset;
    private Vector3 nextNavigationPoint = Vector3.zero;

    private bool arrowToggle = true;


    private void Start()
    {
        path = new NavMeshPath();
        UpdateArrowVisibility();


    }
    private void Update()
    {
        CalculatePath();

        AddOffsetToPath();
        SelectNextNavigationPoint();

        arrow.transform.LookAt(nextNavigationPoint);
    }

    private void CalculatePath()
    {
        int selectedValue = targetDropdown.value;
        Target selectedTarget = targetObjects.Count > selectedValue ? targetObjects[selectedValue] : null;

        if (selectedTarget != null)
        {
            
            NavMesh.CalculatePath(transform.position, selectedTarget.PositionObject.transform.position, NavMesh.AllAreas, path);
        }
    }

    private void AddOffsetToPath()
    {
        pathOffset = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            pathOffset[i] = new Vector3(path.corners[i].x, transform.position.y, path.corners[i].z);
        }
    }

    private void SelectNextNavigationPoint()
    {
        nextNavigationPoint = SelectNextNavigationPointWithinDistance();
    }

    private Vector3 SelectNextNavigationPointWithinDistance()
    {
        for (int i = 0; i < pathOffset.Length; i++)
        {
            currentDistance = Vector3.Distance(transform.position, pathOffset[i]);
            if (currentDistance > moveOnDistance)
            {
                return pathOffset[i];
            }
        }
        return targetDropdown.value < targetObjects.Count ? targetObjects[targetDropdown.value].PositionObject.transform.position : Vector3.zero;
    }
    public void ToggleArrowVisibility()
    {
        arrowToggle = !arrowToggle;
        UpdateArrowVisibility();
    }

    private void UpdateArrowVisibility()
    {
        arrow.SetActive(arrowToggle);
    }
}
