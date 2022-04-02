using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{

    /// <summary>
    /// Gets the coordinates of the drone in a Vector2 object.
    /// </summary>
    public Vector2 getCoords() { return new Vector2(transform.position.x, transform.position.z); }

}
