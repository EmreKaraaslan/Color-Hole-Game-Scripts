using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class DecideSituations : MonoBehaviour
{
    public Vector3 firstPlaneeStartingPosition;
    public Vector3 firstPlaneEndPosition;
    public Vector3 secondPlaneStartingPosition;

    public bool isTrasferPeriod;

    public float firstPlanePositiveCubes;
    public float secondPlanePositiveCubes;

    [SerializeField] GameObject firstPlanePositiveCubeParent;
    [SerializeField] GameObject secondPlanePositiveCubeParent;

    CubeCollisions collisionInfo;


    void Start()
    {
        collisionInfo = FindObjectOfType<CubeCollisions>();

        firstPlanePositiveCubes = firstPlanePositiveCubeParent.transform.childCount;
        secondPlanePositiveCubes = secondPlanePositiveCubeParent.transform.childCount;

        transform.position = firstPlaneeStartingPosition;
    }


    void Update()
    {   
        MoveHolewithAnimation();  
    }

    private void MoveHolewithAnimation()
    {
      
        if (collisionInfo.collidedCube == firstPlanePositiveCubes)
        {
            
            DOTween.Play("First Move");
            DOTween.Play("Second Move");
            DOTween.Play("Camera Movement");
        }
        
    }


}
