using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacle : MonoBehaviour
{
    [HideInInspector] public WarnDistances sensor;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<WarnDistances>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
