using UnityEngine;
using DG.Tweening;
using System.Drawing;
public class GetCameraLittle : MonoBehaviour
{
    public Camera camera;
    public Transform chushikongjian;
    public Transform zhiwu;
    private bool isfollow1=false;
    private bool isfollow2=false;
    public GameObject shoudiantong;
    public Transform genjianzuopiao;
    public Transform matongzuobiao;
    public GameObject matong;
    float juli = 0;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        GetLittle();
    }
    private void Start()
    {
        matong.GetComponent<Animator>().enabled = false;
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
        matongLight();
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
        camera.orthographicSize = 2.57f;
    }
    public void jiancejuli()
    {
        float juli = Vector3.Distance(matongzuobiao.position, camera.transform.position);    }
    public void matongLight()
    {
        jiancejuli();
        if (juli<=1.6)
            matong.GetComponent<Animator>().enabled = true;
    }
}
