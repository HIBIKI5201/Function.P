using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class StrokeController : MonoBehaviour
{
    [SerializeField] Material lineMaterial;
    [SerializeField] Color lineColor;
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    [SerializeField] GameObject movebox;
    int i = 0;

    GameObject lineObj;
    LineRenderer lineRenderer;
    List<Vector2> linePoints;

    public float x = 0;
    public float z = 0;
    public float theta = 0;
    [SerializeField] float _Speed = 2;
    [SerializeField]float r =1;
    void Start()
    {
        //ListÇÃèâä˙âª
        linePoints = new List<Vector2>();
        _addLineObject();
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _addLineObject();
        //}
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    _addPositionDataToLineRenderer();
        //}
        //Debug.Log(transform.position);
        _addPositionDataToLineRenderer();
        x += 1 * Time.deltaTime; //r * Mathf.Sin(theta);
        z = r * Mathf.Cos(theta);

        movebox.transform.position = new Vector3(x, Mathf.Sin(3 * theta), 0);
        theta += (_Speed * Mathf.PI / 360);
    }

    private void _addLineObject()
    {
        lineObj = new GameObject();
        lineObj.name = "Line";
        lineObj.AddComponent<LineRenderer>();
        lineObj.AddComponent<EdgeCollider2D>();
        lineObj.transform.SetParent(transform);
        _initRenderer();
    }

    private void _initRenderer()
    {
        lineRenderer = lineObj.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = lineMaterial;
        lineRenderer.material.color = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    private void _addPositionDataToLineRenderer()
    {
        //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
        //Vector3 worldPos = transform.position;//Camera.main.ScreenToWorldPoint(mousePos);


        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, movebox.transform.position);
        linePoints.Add(movebox.transform.position);
        lineObj.GetComponent<EdgeCollider2D>().SetPoints(linePoints);
    }
}