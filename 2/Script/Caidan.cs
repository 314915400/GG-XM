using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Caidan : MonoBehaviour
{
    public List<GameObject> caidanduihua;
    public void OnButton()
    {
        foreach (GameObject go in caidanduihua )
        {
            go.SetActive( true );
        }
    }
}
