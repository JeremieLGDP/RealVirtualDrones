using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{   
    Rigidbody droneRB;

    private int pitch = 0;
    /// <summary>
    /// Gets the pitch in milli Radians (0 - 2000Pi mRad == 0 - 360°)
    /// </summary>
    public int getPitch() { return pitch; }

    private int roll = 0;
    /// <summary>
    /// Gets the actual roll in milli Radians (0 - 2000Pi mRad == 0 - 360°)
    /// </summary>
    public int getRoll() { return roll; }

    private int yaw = 0;
    /// <summary>
    /// Gets the actual yaw in milli Radians (0 - 2000Pi mRad == 0 - 360°)
    /// </summary>
    public int getYaw() { return yaw; }

    private int ratePitch = 0;
    /// <summary>
    /// Gets the pitch rate in mRad/s. Max = 5,000 * 2*Pi mRad/s (5 complete circles per second)
    /// </summary>
    public int getRatePitch() { return ratePitch; }

    private int rateRoll = 0;
    /// <summary>
    /// Gets the roll rate in mRad/s. Max = 5,000 * 2*Pi mRad/s (5 complete circles per second)
    /// </summary>
    public int getRateRoll() { return rateRoll; }

    private int rateYaw = 0;
    /// <summary>
    /// Gets the yaw rate in mRad/s. Max = 5,000 * 2*Pi mRad/s (5 complete circles per second)
    /// </summary>
    public int getRateYaw() { return rateYaw; }


    /// <summary>
    /// Function called before of the first update
    /// </summary>
    void Start()
    {
        droneRB = GetComponent<Rigidbody>();

    }

    /// <summary>
    /// Function at regular time interval, same as physics calculations. Usually way above FPS or "Update" loops.
    /// </summary>
    void FixedUpdate()
    {
        // Calculate values and convert them from ° and °/s to mRad and mRad/s in order to match the Crazyflie drones and their sensors.
        Vector3 angularVelocity = droneRB.angularVelocity;
        int rateRoll = (int) (angularVelocity.x * 1000 * 2 * 3.1415 /360);
        int ratePitch = (int) (angularVelocity.z * 1000 * 2 * 3.1415 /360);
        int rateYaw = (int) (angularVelocity.y * 1000 * 2 * 3.1415 /360);

        Vector3 rotation = droneRB.rotation.eulerAngles;
        int roll = (int) (rotation.x * 1000 * 2 * 3.1415 /360);
        int pitch = (int) (rotation.z * 1000 * 2 * 3.1415 /360);
        int yaw = (int) (rotation.y * 1000 * 2 * 3.1415 /360);

    }

}
