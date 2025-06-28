using UnityEngine;
using DG.Tweening;
using System.Drawing;
using UnityEngine.UI;
using Unity.VisualScripting;
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
    ////////////////////////////////////////////////////////////////////////////////////////////
    [Header("��һ������")]
    public GameObject sliderwuti1;
    public GameObject sliderwuti2;
    //[Header("�ڶ�������")]
    //public GameObject sliderwuti3;
    //public GameObject sliderwuti4;
    //[Header("����������")]
    //public GameObject sliderwuti5;
    //public GameObject sliderwuti6;
    [Header("��һ�黬��")]
    public Slider slider1; // ��ק Slider ������������
    public Transform cameraTransform1; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    public Vector3 moveDirection1 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    public float minDistance1 = 0f; // ��������ͷ�ƶ�����С����
    public float maxDistance1 = 10f; // ��������ͷ�ƶ���������
    public Slider slider2; // ��ק Slider ������������
    public Transform cameraTransform2; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    public Vector3 moveDirection2 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    public float minDistance2 = 0f; // ��������ͷ�ƶ�����С����
    public float maxDistance2 = 10f; // ��������ͷ�ƶ���������
    //[Header("�ڶ��黬��")]
    //public Slider slider3; // ��ק Slider ������������
    //public Transform cameraTransform3; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    //public Vector3 moveDirection3 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    //public float minDistance3 = 0f; // ��������ͷ�ƶ�����С����
    //public float maxDistance3 = 10f; // ��������ͷ�ƶ���������
    //public Slider slider4; // ��ק Slider ������������
    //public Transform cameraTransform4; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    //public Vector3 moveDirection4 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    //public float minDistance4 = 0f; // ��������ͷ�ƶ�����С����
    //public float maxDistance4= 10f; // ��������ͷ�ƶ���������

    //[Header("�����黬��")]
    //public Slider slider5; // ��ק Slider ������������
    //public Transform cameraTransform5; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    //public Vector3 moveDirection5 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    //public float minDistance5 = 0f; // ��������ͷ�ƶ�����С����
    //public float maxDistance5 = 10f; // ��������ͷ�ƶ���������
    //public Slider slider6; // ��ק Slider ������������
    //public Transform cameraTransform6; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    //public Vector3 moveDirection6 = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    //public float minDistance6 = 0f; // ��������ͷ�ƶ�����С����
    //public float maxDistance6 = 10f; // ��������ͷ�ƶ���������


    private void Start()
    {
        zhuchangjing.GetComponent<Animator>().enabled = false;
        // ��ʼ�� Slider ��ֵ��Χ
        slider1.minValue = minDistance1;
        slider1.maxValue = maxDistance1;
        slider1.value = (minDistance1 + maxDistance1) / 2; 
        // ���ó�ʼֵΪ�м�ֵ
        slider2.minValue = minDistance2;
        slider2.maxValue = maxDistance2;
        slider2.value = (minDistance2 + maxDistance2) / 2;
        //// ���ó�ʼֵΪ�м�ֵ
        //slider3.minValue = minDistance3;
        //slider3.maxValue = maxDistance3;
        //slider3.value = (minDistance3 + maxDistance3) / 2; 
        //// ���ó�ʼֵΪ�м�ֵ
        //slider4.minValue = minDistance4;
        //slider4.maxValue = maxDistance4;
        //slider4.value = (minDistance4 + maxDistance4) / 2; 
        //// ���ó�ʼֵΪ�м�ֵ
        //slider5.minValue = minDistance5;
        //slider5.maxValue = maxDistance5;
        //slider5.value = (minDistance5 + maxDistance5) / 2; 
        //// ���ó�ʼֵΪ�м�ֵ
        //slider6.minValue = minDistance6;
        //slider6.maxValue = maxDistance6;
        //slider6.value = (minDistance6 + maxDistance6) / 2; 

    }

    // �� Slider ֵ�ı�ʱ���ô˷���
    public void OnSliderValueChanged()
    {
        UpdateCameraPosition();
    }

    // ���� Slider ֵ��������ͷλ��
    private void UpdateCameraPosition()
    {
        float distance1 = slider1.value; // ��ȡ Slider ��ǰֵ
        cameraTransform1.position = transform.position + moveDirection1.normalized * distance1; // ���ݷ���;�����������ͷλ��
        float distance2 = slider2.value; // ��ȡ Slider ��ǰֵ
        //cameraTransform2.position = transform.position + moveDirection2.normalized * distance2; // ���ݷ���;�����������ͷλ��
        //float distance3 = slider1.value; // ��ȡ Slider ��ǰֵ
        //cameraTransform1.position = transform.position + moveDirection3.normalized * distance3; // ���ݷ���;�����������ͷλ��
        //float distance4 = slider2.value; // ��ȡ Slider ��ǰֵ
        //cameraTransform2.position = transform.position + moveDirection4.normalized * distance4; // ���ݷ���;�����������ͷλ��
        //float distance5 = slider1.value; // ��ȡ Slider ��ǰֵ
        //cameraTransform1.position = transform.position + moveDirection5.normalized * distance5; // ���ݷ���;�����������ͷλ��
        //float distance6 = slider2.value; // ��ȡ Slider ��ǰֵ
        //cameraTransform2.position = transform.position + moveDirection6.normalized * distance6; // ���ݷ���;�����������ͷλ��
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
    public void shoudiantongONbutton()
    {
        CameraFollow1();
        shoudiantong3.SetActive(true);
        shoudiantong1.SetActive(false);
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
            sliderwuti1.SetActive(true);
            sliderwuti2.SetActive(true);
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
}
