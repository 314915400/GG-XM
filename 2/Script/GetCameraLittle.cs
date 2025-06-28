using UnityEngine;
using DG.Tweening;
using System.Drawing;
using UnityEngine.UI;
public class GetCameraLittle : MonoBehaviour
{
    public Camera camera;
    public Transform chushikongjian;
    public Transform zhiwu;
    private bool isfollow1=false;
    private bool isfollow2=false;
    public GameObject shoudiantong;
    public Transform matongzuobiao;
    public GameObject matong;
    ////////////////////////////////////////////////////////////////////////////////////////////

    public Slider slider; // 拖拽 Slider 组件到这个变量
    public Transform cameraTransform; // 拖拽需要移动的摄像头的 Transform 组件到这个变量
    public Vector3 moveDirection = Vector3.forward; // 设置摄像头移动的方向，默认为向前移动
    public float minDistance = 0f; // 设置摄像头移动的最小距离
    public float maxDistance = 10f; // 设置摄像头移动的最大距离

    private void Start()
    {
        // 初始化 Slider 的值范围
        slider.minValue = minDistance;
        slider.maxValue = maxDistance;
        slider.value = (minDistance + maxDistance) / 2; // 设置初始值为中间值

    }

    // 当 Slider 值改变时调用此方法
    public void OnSliderValueChanged()
    {
        UpdateCameraPosition();
    }

    // 根据 Slider 值更新摄像头位置
    private void UpdateCameraPosition()
    {
        float distance = slider.value; // 获取 Slider 当前值
        cameraTransform.position = transform.position + moveDirection.normalized * distance; // 根据方向和距离设置摄像头位置
    }

/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
private void Awake()
    {
        camera = GetComponent<Camera>();
        GetLittle();

    }

    private void Update()
    {
        if (camera.orthographicSize>0.93)
        camera.orthographicSize -= Time.deltaTime * 10;
        if (isfollow1)
        {
            CameraFollow2();
        }
        if (isfollow2)
        {         
        Mouse2yidong();
        }
    }
    public void GetLittle()
    {
        Vector3 fangjian1Position= chushikongjian.position;
        fangjian1Position.z = -10;
        camera.transform.DOPath(new Vector3[] { camera.transform.position, fangjian1Position}, 3)
           .SetEase(Ease.OutQuad)
             .OnComplete(
            () =>
            {
                Invoke("Shengchengshoudiantong", 0.2f);
            }
            );
    }
    public void Shengchengshoudiantong()
    {
        shoudiantong.SetActive(true);
    }
    public void shoudiantongONbutton()
    {
        CameraFollow1();
        isfollow2 = true;
    }
    public void Mouse2yidong()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousePosition.z = -10;
            camera.transform.position = MousePosition;
            matong.SetActive(true);
        }


    }

    public void CameraFollow1()
    {
        Vector3 zhiwuPosition = zhiwu.position;
        zhiwuPosition.z = -10;
        camera.transform.DOPath(new Vector3[] { camera.transform.position, zhiwuPosition }, 1)
           .SetEase(Ease.OutQuad);
        isfollow1=true;

    }
    public void CameraFollow2()
    {
        Vector3 zhiwuPosition = zhiwu.position;
        zhiwuPosition.z = -10;
        camera.transform.position = zhiwuPosition;
        camera.orthographicSize = 3f;
        UpdateCameraPosition();

    }
    public void shixiangjiyidong()
    {
        

    }

}
