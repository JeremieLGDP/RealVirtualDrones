using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotor : MonoBehaviour 
{

    Rigidbody rBody;
    float power;
    
    /// <summary>
    /// Which way the blade is rotating
    /// <para> Set this in the editor
    /// </summary>
    public bool counterclockwise = false;
    
    /// <summary>
    /// Animated rotors or not? (Only visual)
    /// <para> Set this in the editor
    /// </summary>
    public bool animationOn = false;

    /// <summary>
    /// Function called before of the first update
    /// </summary>
    void Start()
    {        
        Transform t = this.transform;
        while (t.parent != null && t.tag != "Player") t = t.parent;
        rBody = t.GetComponent<Rigidbody>();
    }
    
    /// <summary>
    /// Function called once per frame
    /// </summary>
    void Update() { if (animationOn) transform.Rotate(0, 0, 10 * 700 * Time.deltaTime * (counterclockwise ? -1 : 1)); }

}