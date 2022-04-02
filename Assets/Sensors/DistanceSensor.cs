using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSensor : MonoBehaviour
{
    Vector3 distancesDFL;
    Vector3 distancesUBR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray upRay = new Ray(transform.position, transform.up);
        Ray downRay = new Ray(transform.position, -transform.up);
        Ray frontRay = new Ray(transform.position, transform.forward);
        Ray backRay = new Ray(transform.position, - transform.forward);
        Ray rightRay = new Ray(transform.position, transform.right);
        Ray leftRay = new Ray(transform.position, -transform.right);

        if (Physics.Raycast(downRay, out hit))
        {
            // The "error" in height is the difference between the desired height
            // and the height measured by the raycast distance.
            distancesDFL.x = hit.distance;
        }
        if (Physics.Raycast(frontRay, out hit))
        {
            distancesDFL.y = hit.distance;
        }
        if (Physics.Raycast(leftRay, out hit))
        {
            distancesDFL.z = hit.distance;
        }
        if (Physics.Raycast(upRay, out hit))
        {
            distancesUBR.x = hit.distance;
        }
        if (Physics.Raycast(backRay, out hit))
        {
            distancesUBR.y = hit.distance;
        }
        if (Physics.Raycast(rightRay, out hit))
        {
            distancesUBR.z = hit.distance;
        }
        // Debug.Log(distancesDFL);
    }
}
