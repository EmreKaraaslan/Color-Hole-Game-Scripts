using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoundries : MonoBehaviour
{
    public bool inPlane1;
    public bool inPlane2;

    [SerializeField] Transform leftBoundary;
    [SerializeField] Transform rightBoundary;
    [SerializeField] Transform plane1UpBoundary;
    [SerializeField] Transform plane1DownBoundary;
    [SerializeField] Transform plane2UpBoundary;
    [SerializeField] Transform plane2DownBoundary;

    
    void Start()
    {
        inPlane1 = true;
        inPlane2 = false;
    }


    void Update()
    {
        SetXBoundries();
        SetZBoundries();
    }
    void SetXBoundries()
    {
       if(transform.position.x<=leftBoundary.transform.position.x)
        {
            transform.position = new Vector3(leftBoundary.transform.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= rightBoundary.transform.position.x)
        {
            transform.position = new Vector3(rightBoundary.transform.position.x, transform.position.y, transform.position.z);
        }

    }

    void SetZBoundries()
    {
        if(inPlane1)
        {
            if(transform.position.z>=plane1UpBoundary.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, plane1UpBoundary.transform.position.z);
            }

            if (transform.position.z <= plane1DownBoundary.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, plane1DownBoundary.transform.position.z);
            }

        }


        if (inPlane2)
        {
            if (transform.position.z >= plane2UpBoundary.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, plane2UpBoundary.transform.position.z);
            }

            if (transform.position.z <= plane2DownBoundary.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, plane2DownBoundary.transform.position.z);
            }

        }
    }

    public void SetinPlane2True()
    {
        inPlane1 = false;
        inPlane2 = true;
    }

}
