using UnityEngine;
using UnityEngine.UI;

public class 物体基类 : MonoBehaviour
{
    public Sprite[] 图片数组; // 预设的图片数组
    public Image 图片渲染器; // 用于显示图片的Image组件
    public int 当前状态; // 当前状态，用于索引图片数组

    public bool 是否可点击;
    public Button 自己;

    void Start()
    {
        自己 = GetComponent<Button>();
        自己.onClick.AddListener(() => 互动(当前状态));
    }


    // 互动函数，接受一个int参数
    public void 互动(int 参数)
    {
        if(是否可点击)
        {
            VNmang.Instance.LoadGame(参数);
        }
 
    }

}
