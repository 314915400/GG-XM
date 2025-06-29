using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class 物体基类 : MonoBehaviour
{
    public Sprite[] 图片数组; // 预设的图片数组
    public SpriteRenderer 图片渲染器; // 用于显示图片的SpriteRenderer组件
    public int 当前状态 = 1; // 当前状态，用于索引图片数组

    public bool 是否可点击 = true;

    public float 淡入时间 = 1.0f; // 淡入时间
    public float 淡出时间 = 1.0f; // 淡出时间

    public Animator 动画机;

    // 淡入函数
    public IEnumerator FadeIn(int 图片索引)
    {
        if (图片索引 >= 0 && 图片索引 < 图片数组.Length)
        {
            图片渲染器.sprite = 图片数组[图片索引];
            Color color = 图片渲染器.color;
            color.a = 0; // 初始透明度为0
            图片渲染器.color = color;

            float elapsedTime = 0;
            while (elapsedTime < 淡入时间)
            {
                color.a = elapsedTime / 淡入时间;
                图片渲染器.color = color;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            color.a = 1;
            图片渲染器.color = color;
        }
        else
        {
            Debug.LogError("图片索引超出范围: " + 图片索引);
        }
    }

    // 淡出函数
    public IEnumerator FadeOut()
    {
        Color color = 图片渲染器.color;
        float elapsedTime = 0;
        while (elapsedTime < 淡出时间)
        {
            color.a = 1 - (elapsedTime / 淡出时间);
            图片渲染器.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        图片渲染器.color = color;
    }


    public void xxx()
    {
        动画机.SetTrigger("xxx");
    }
    

    
 

    // 互动函数，接受一个int参数
    public void 互动(int 参数)
    {
        // 调用玩家的LoadGame方法
        VNmang.Instance.LoadGame(参数);

    }
}