using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    Rigidbody droneRB;

    private Vector3Int acceleration = new Vector3Int(0,0,0);
    /// <summary>
    /// Gets the acceleration in mm/s². 
    /// </summary>
    public Vector3Int getAcceleration() { return acceleration; }

    private Vector3 velocityF = new Vector3(0,0,0);
    private Vector3Int velocity = new Vector3Int(0,0,0);
    /// <summary>
    /// Gets the velocity in mm/s.
    /// </summary>
    public Vector3Int getVelocity() { return velocity; }

    /// <summary>
    ///  Start is called before the first frame update
    ///  </summary>
    void Start()
    {
        droneRB = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixedUpdate is called as often as physics (several times per frame)
    /// </summary>
    void FixedUpdate()
    {
        // Calculate values and convert them from m/s and m/s² to mm/s and mm/s² in order to match the Crazyflie drones and their sensors. 
        // Time.fixedDeltaTime is the time between each loop of the physics, as well as each loop of the "FixedUpdate()" functions.
        Vector3 accelerationF = (droneRB.velocity - velocityF)/Time.fixedDeltaTime;
        acceleration.x = (int) (accelerationF.x * 1000);
        acceleration.y = (int) (accelerationF.y * 1000);
        acceleration.z = (int) (accelerationF.z * 1000);

        velocityF = droneRB.velocity;
        velocity.x = (int) (velocityF.x * 1000);
        velocity.y = (int) (velocityF.y * 1000);
        velocity.z = (int) (velocityF.z * 1000);

        // Debug.Log(velocity);

    }
}
