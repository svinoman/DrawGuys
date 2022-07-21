using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PathCreator : MonoBehaviour
{
    private int amogusPoints;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            points.Clear();
        }
        if(Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (DistanceToLastPoint(hitInfo.point) > 0.001f)
                {
                    points.Add(hitInfo.point);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                OnNewPathCreated(points);
            }
        }
        if(Input.GetButtonUp("Fire1"))
        {
            amogusPoints = points.Count / GameObject.FindGameObjectsWithTag("amogus").Length;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("amogus").Length; i++)
            {
                if(i == 0)
                {
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.position = new Vector3(points[i].x, points[i].y, points[i].z);
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(3).transform.GetComponent<ParticleSystem>().Play();
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(3).transform.GetComponent<AudioSource>().Play();
                }
                else
                {
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.position = new Vector3(points[amogusPoints * i].x, points[amogusPoints * i].y, points[amogusPoints * i].z);
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(3).transform.GetComponent<ParticleSystem>().Play();
                    GameObject.FindGameObjectsWithTag("amogus")[i].transform.GetChild(3).transform.GetComponent<AudioSource>().Play();
                }


            }

            //for (int i = 0; i < points.Count; i++)
            // {
            //    GameObject.FindGameObjectsWithTag("amogus")[i].transform.position = new Vector3(points[i].x, points[i].y, points[i].z);
            //}
        }
    }
    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
        {
            return Mathf.Infinity;
        }
        return Vector3.Distance(points.Last(), point);
    }
}
