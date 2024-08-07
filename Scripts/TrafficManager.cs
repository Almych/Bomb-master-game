using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    
    [SerializeField] TrafficColors traffic;
    private int[] movePoints;
    private int xRot = 0;

    private void Start()
    {
        movePoints = new int[] { -6, -2, -3};
        traffic.CheckNumber(RandomPosition);
    }

    private void RandomPosition ()
    {
        int randomPoint = Random.Range(0, movePoints.Length);
        xRot = movePoints[randomPoint];
        transform.position = new Vector3(xRot, transform.position.y, transform.position.z);
    }

   
    
}
