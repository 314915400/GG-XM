
using UnityEngine;
using UnityEngine.UI;

public class 玩家 : MonoBehaviour
{
    // 示例：玩家的一个属性
    public int 玩家属性A;

    // 修改玩家属性的方法
    public void 修改玩家属性(int 参数)
    {
        // 示例：根据参数修改玩家属性A
        玩家属性A = 参数;
        Debug.Log("玩家的属性A已修改为：" + 玩家属性A);
    }



    //public GameObject 当前区域;

    //public Button 左上;
    //public Button 中上;
    //public Button 右上;
    //public Button 中左;
    //public Button 中右;
    //public Button 左下;
    //public Button 中下;
    //public Button 右下;

    //private void Start()
    //{
    //    // 初始化按钮状态
    //    初始化按钮状态();

    //    // 为按钮绑定点击事件
    //    左上.onClick.AddListener(() => 移动(1));
    //    中上.onClick.AddListener(() => 移动(2));
    //    右上.onClick.AddListener(() => 移动(3));
    //    中左.onClick.AddListener(() => 移动(4));
    //    中右.onClick.AddListener(() => 移动(5));
    //    左下.onClick.AddListener(() => 移动(6));
    //    中下.onClick.AddListener(() => 移动(7));
    //    右下.onClick.AddListener(() => 移动(8));
    //}

    //public void 初始化按钮状态()
    //{
    //    区域基类 当前区域脚本 = 当前区域.GetComponent<区域基类>();
    //    if (当前区域脚本 != null)
    //    {
    //        左上.interactable = 当前区域脚本.下一个区域左上 != null;
    //        中上.interactable = 当前区域脚本.下一个区域中上 != null;
    //        右上.interactable = 当前区域脚本.下一个区域右上 != null;
    //        中左.interactable = 当前区域脚本.下一个区域中左 != null;
    //        中右.interactable = 当前区域脚本.下一个区域中右 != null;
    //        左下.interactable = 当前区域脚本.下一个区域左下 != null;
    //        中下.interactable = 当前区域脚本.下一个区域中下 != null;
    //        右下.interactable = 当前区域脚本.下一个区域右下 != null;
    //    }
    //}

    //public void 移动(int 方向)
    //{
    //    if (当前区域 != null)
    //    {
    //        区域基类 当前区域脚本 = 当前区域.GetComponent<区域基类>();
    //        if (当前区域脚本 != null)
    //        {
    //            当前区域脚本.移动到下一个区域(方向);
    //        }
    //    }
    //}
}