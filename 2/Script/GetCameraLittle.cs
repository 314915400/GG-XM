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

    public Slider slider; // ��ק Slider ������������
    public Transform cameraTransform; // ��ק��Ҫ�ƶ�������ͷ�� Transform ������������
    public Vector3 moveDirection = Vector3.forward; // ��������ͷ�ƶ��ķ���Ĭ��Ϊ��ǰ�ƶ�
    public float minDistance = 0f; // ��������ͷ�ƶ�����С����
    public float maxDistance = 10f; // ��������ͷ�ƶ���������

    private void Start()
    {
        // ��ʼ�� Slider ��ֵ��Χ
        slider.minValue = minDistance;
        slider.maxValue = maxDistance;
        slider.value = (minDistance + maxDistance) / 2; // ���ó�ʼֵΪ�м�ֵ

    }

    // �� Slider ֵ�ı�ʱ���ô˷���
    public void OnSliderValueChanged()
    {
        UpdateCameraPosition();
    }

    // ���� Slider ֵ��������ͷλ��
    private void UpdateCameraPosition()
    {
        float distance = slider.value; // ��ȡ Slider ��ǰֵ
        cameraTransform.position = transform.position + moveDirection.normalized * distance; // ���ݷ���;�����������ͷλ��
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
