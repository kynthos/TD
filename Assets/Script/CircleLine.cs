using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLine : MonoBehaviour
{
    public float radius = 1f;
    float prevRadius = 0f;

    public float lineWidth = 0.1f;

    LineRenderer lineRender;

    private void Start()
    {
        lineRender = gameObject.AddComponent<LineRenderer>();
        lineRender.startColor = lineRender.endColor = Color.white;
    }

    public void Update()
    {
        if (CheckLineUpdate())
            UpdateLine();
    }

    bool CheckLineUpdate()
    {
        return lineRender.startWidth != lineWidth || prevRadius != radius;
    }

    void UpdateLine()
    {
        prevRadius = radius;

        var segments = 360;
        lineRender.startWidth = lineWidth;
        lineRender.endWidth = lineWidth;
        lineRender.positionCount = segments + 1;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0);
        }

        lineRender.SetPositions(points);
    }
}
