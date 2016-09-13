using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(LineRenderer))]
public class Bezier : MonoBehaviour
{
    [SerializeField]
    //public LTBezierPath a;
    public int[] speedOfNextLine;
    public Transform[] controlPoints;
    public LineRenderer lineRenderer;
    bool finished = false;
    int nowCurve = 0;
    private int curveCount = 0;
    private int layerOrder = 0;
    private int SEGMENT_COUNT = 50;
    int wait = 1;

    void Start()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        lineRenderer.sortingLayerID = layerOrder;
        curveCount = (int)controlPoints.Length / 3;
        //StartCoroutine(DrawCall());
    }

    void Update()
    {

       if(!finished) DrawCurve();

    }

    //try
    IEnumerator DrawCall() {
 
        while (true) {
            if (nowCurve + 1 < curveCount)
            {
                if (nowCurve == 0)
                {
                    subDraw(nowCurve, 0,true);
                    subDraw(nowCurve + 1, 1,false);
                    subDraw(nowCurve + 2, 2,false);
                }
                else {
                    subDraw(nowCurve - 1, 0,false);
                    subDraw(nowCurve, 1,true);
                    subDraw(nowCurve + 1, 2,false);
                }
                wait = speedOfNextLine[nowCurve]; 
                nowCurve += 1;
            }
            else {
                StopCoroutine(DrawCall());
            }
            yield return new WaitForSeconds(wait);
        }
    }

    void subDraw(int j,int k,bool savePoint) {
        //print(nowCurve);
        for (int i = 1; i <= SEGMENT_COUNT; i++)
        {
            
            //float t = i / (float)SEGMENT_COUNT;
            //int nodeIndex = j * 3;
            //Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position, controlPoints[nodeIndex + 3].position);
            Vector3 pixel = followLineMoving.waypoints[(j * SEGMENT_COUNT) + (i - 1)];

            lineRenderer.SetVertexCount(150);
            lineRenderer.SetPosition((k*SEGMENT_COUNT+(i - 1)), pixel);
            //correspond with followLineMovind.cs
            //if(savePoint)followLineMoving.waypoints.Add(pixel);
        }
    }

    void DrawCurve()
    {
        for (int j = 0; j < curveCount; j++)
        {
            for (int i = 1; i <= SEGMENT_COUNT; i++)
            {
                float t = i / (float)SEGMENT_COUNT;
                int nodeIndex = j * 3;
                Vector3 pixel = CalculateCubicBezierPoint(t, controlPoints[nodeIndex].position, controlPoints[nodeIndex + 1].position, controlPoints[nodeIndex + 2].position, controlPoints[nodeIndex + 3].position);
                /*lineRenderer.SetVertexCount(((j * SEGMENT_COUNT) + i));
                lineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);*/
                //correspond with followLineMovind.cs
                followLineMoving.waypoints.Add(pixel);
            }

        }
        finished = true;
        StartCoroutine(DrawCall());
    }

    /*void leantweenfunction() {
        LeanTween.move(gameObject, a, 1f);
    }*/
    
    Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}