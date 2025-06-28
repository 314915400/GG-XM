using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 点击预设体 : MonoBehaviour
{
    void Start()
    {
        Invoke("ddd",2f);
    }
    void ddd()
    {
        GameObject.Destroy(gameObject);
    }



    void OnTriggerEnter(Collider other)
    {
        物体基类 wu = other.GetComponent<物体基类>();
        if(wu.是否可点击)
        {
            wu.互动(wu.当前状态);
        }
        ddd();
    }
}
