using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GetCameraLittle : MonoBehaviour
{
    public Camera camera;
    public Transform chushikongjian;
    public Transform zhiwu;
    private bool isfollow1=false;
    private bool isfollow2=false;
    public GameObject shoudiantong1;
    public GameObject shoudiantong2;
    public GameObject shoudiantong3;
    public Transform matongzuobiao;
    public GameObject matong;
    public GameObject zhuchangjing ;
    public 物体基类 wutijilei;
    public bool isAnimation=false;
    ////////////////////////////////////////////////////////////////////////////////////////////
    [Header("第一组物体")]
    public GameObject sliderwuti1;
    public GameObject sliderwuti2;
    [Header("第一组滑块")]
    public Slider slider1; // 拖拽 Slider 组件到这个变量
    public Transform cameraTransform1; // 拖拽需要移动的摄像头的 Transform 组件到这个变量
    public Vector3 moveDirection1 = Vector3.forward; // 设置摄像头移动的方向，默认为向前移动
    public float minDistance1 = 0f; // 设置摄像头移动的最小距离
    public float maxDistance1 = 10f; // 设置摄像头移动的最大距离
    public Slider slider2; // 拖拽 Slider 组件到这个变量
    public Transform cameraTransform2; // 拖拽需要移动的摄像头的 Transform 组件到这个变量
    public Vector3 moveDirection2 = Vector3.forward; // 设置摄像头移动的方向，默认为向前移动
    public float minDistance2 = 0f; // 设置摄像头移动的最小距离
    public float maxDistance2 = 10f; // 设置摄像头移动的最大距离


    private void Start()
    {
        zhuchangjing.GetComponent<Animator>().enabled = false;
         //初始化 Slider 的值范围
        slider1.minValue = minDistance1;
        slider1.maxValue = maxDistance1;
        slider1.value = (minDistance1 + maxDistance1) / 2; // 设置初始值为中间值
        slider2.minValue = minDistance2;
        slider2.maxValue = maxDistance2;
        slider2.value = (minDistance2 + maxDistance2)/2;      // 设置初始值为中间值

    }

    //当 Slider 值改变时调用此方法
    public void OnSliderValueChanged()
    {
        UpdateCameraPosition();
    }

    //根据 Slider 值更新摄像头位置
    private void UpdateCameraPosition()
    {
        float distance1 = slider1.value; // 获取 Slider 当前值
        cameraTransform1.position = transform.position + moveDirection1.normalized * distance1; // 根据方向和距离设置摄像头位置
        float distance2 = slider2.value; // 获取 Slider 当前值
        cameraTransform2.position = transform.position + moveDirection2.normalized * distance2; // 根据方向和距离设置摄像头位置
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
        if (camera.orthographicSize>1.2)
        camera.orthographicSize -= Time.deltaTime * 5;
        if (isfollow1)
        {
            CameraFollow2();
        }

        if (isfollow2)
        {         
        Mouse2yidong();

       UpdateCameraPosition();

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
        shoudiantong1.SetActive(true);
    }
    public void tranTotrue()
    {
        if(isAnimation)
        wutijilei.xxx();
    }
        
    public void shoudiantongONbutton()
    {
        CameraFollow1();
        shoudiantong3.SetActive(true);
        shoudiantong1.SetActive(false);
        isfollow1 = true;
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
       //Invoke("tranfollow1true", 2);
        tranfollow1true();
        sliderwuti1.SetActive(true);
        sliderwuti2.SetActive(true);
    }

    private void tranfollow1true()
    {
        isfollow1 = true;
    }

    public void CameraFollow2()
    {
        Vector3 zhiwuPosition2 = zhiwu.position;
        zhiwuPosition2.z = -10;
        Camera.main.transform.position = zhiwuPosition2;
        isfollow2 = true;
    }
}
