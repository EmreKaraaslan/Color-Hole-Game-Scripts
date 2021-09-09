using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCollisions : MonoBehaviour
{
    public int collidedCube = 0;

    HoleMovement holeMovement;
    LevelFinish levelFinish;

    Rigidbody rigidbody;
   

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        holeMovement = GetComponent<HoleMovement>();
        levelFinish = GetComponent<LevelFinish>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PositiveCube")
        {
            other.gameObject.tag = "AlreadyCollided";
            collidedCube++;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if (other.gameObject.tag == "NegativeCube")
        {
            other.gameObject.tag = "AlreadyCollided";
            collidedCube--;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            holeMovement.StopMovingHole();
            levelFinish.UnsuccessfulLevel();
                       
        }

        else if(other.gameObject.tag=="MidPlaneCube")
        {
            other.gameObject.tag = "AlreadyCollided";
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

    }

   
}
