using System.Threading;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AgentTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AgentTestForward()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var gameObject = new GameObject();
        var agent = gameObject.AddComponent<FlockAgent>();

        Vector3 fwd = new Vector3(1,0,0);

        agent.Move(fwd);

        yield return new WaitForSeconds(Time.deltaTime);

        Assert.AreEqual(fwd, agent.transform.forward);
    }

    [UnityTest]
    public IEnumerator AgentTestMovement()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        var gameObject = new GameObject();
        var agent = gameObject.AddComponent<FlockAgent>();

        Vector3 fwd = new Vector3(1f,0f,0f);
        Vector3 pos = agent.transform.position;

        agent.Move(fwd);

        yield return new WaitForSeconds(Time.deltaTime);

        Assert.AreEqual( pos + fwd * Time.deltaTime, agent.transform.position);
    }
}
