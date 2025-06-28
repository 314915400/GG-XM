
using UnityEngine;
using UnityEngine.UI;

public class 玩家 : MonoBehaviour
{
    public int 节点数;
    public Vector2[] 节点;
    public Vector2 当前节点;

    public GameObject 枝条;
    private float ti = 0.0f;

    public void 生长()
    {
        GameObject obj = Instantiate(枝条,(Vector3)当前节点,Quaternion.identity);
        节点类 jb = obj.GetComponent<节点类>();
        jb.长(节点[节点数]);
    }

    private void Update()
    {
        if( ti < 0.0f)
        {
            生长();
            ti = 1f;
        }
        ti -= Time.deltaTime;
    }


}