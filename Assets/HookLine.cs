using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HookLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 hookPoint;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        DisableLineRenderer();
    }

    public void StoreHookPoint(Vector3 hookPoint)
    {
        this.hookPoint = hookPoint;
    }

    public void UpdateHookPoint()
    {
        Vector3[] linePoints = { transform.position, hookPoint };
        lineRenderer.SetPositions(linePoints);
    }

    public void EnableLineRenderer()
    {
        lineRenderer.enabled = true;
    }

    public void DisableLineRenderer()
    {
        lineRenderer.enabled = false;
    }
}
