using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 节点类
public class 节点类 : MonoBehaviour
{
    public Vector3 position;
    public float 伸长距离 = 1.0f; // 伸长的距离
    public float 生成点范围 = 0.5f; // 生成新点的范围
    [SerializeField]
    public Vector2 目标点;

    private void Update()
    {
        if(目标点 != null)
        {
            伸长到新点(目标点);
        }

    }

    public void 长(Vector2 a)
    {
        transform.LookAt(a);

        // 2. 生成新点
        Vector3 新点 = 生成新点(a);

        // 3. 伸长到新点
        伸长到新点(新点);
    }
    private Vector3 生成新点(Vector3 目标点)
    {
        // 生成一个随机点，围绕目标点
        Vector3 随机偏移 = new Vector3(
            Random.Range(-生成点范围, 生成点范围),
            Random.Range(-生成点范围, 生成点范围),
            0
        );
        this.目标点 = 目标点;
        return 目标点 + 随机偏移;
    }

    private void 伸长到新点(Vector3 新点)
    {
        // 伸长到新点
        transform.position = Vector3.MoveTowards(transform.position, 新点, 伸长距离 * Time.deltaTime);
    }

}
