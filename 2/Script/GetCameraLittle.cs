using UnityEngine;
using DG.Tweening;
using System.Drawing;
public class GetCameraLittle : MonoBehaviour
{
    public Camera camera;
    [Header("房间位置")]
    public Transform fangjian1;
    public Transform fangjian2;
    public Transform fangjian3;
    public Transform fangjian4;
    public Transform fangjian5;
    [Header("场景物体")]
    public GameObject bingxiang;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Door4;
    [Header("代码引用")]
    public Door1 door1;
    public Door2 door2;
    public Door3 door3;
    public Door4 door4;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        GetLittle();
        
    }
    private void Update()
    {
        if (camera.orthographicSize>3.29)
        camera.orthographicSize -= Time.deltaTime * 10;
        if(door1.isEnd1)
        {
        YidongcameraTo2();
        }
        else if(door2.isEnd2)
        {
            YidongcameraTo3();
        }
        else if(door3.isEnd3)
        {
            YidongcameraTo4();
        }
    }
    public void GetLittle()
    {
        Vector3 fangjian1Position= fangjian1.position;
        fangjian1Position.z = -10;
        camera.transform.DOPath(new Vector3[] { camera.transform.position, fangjian1Position}, 1)
            .SetEase(Ease.OutQuad)
             .OnComplete(
            () =>
            {
                //TODO:激活UI物体
                bingxiang.SetActive(true);
                Door1.SetActive(true);
            }
            );
    }
    public void YidongcameraTo2()
    {
        
            Vector3 fangjian2Position = fangjian2.position;
            fangjian2Position.z = -10;
            camera.transform.DOPath(new Vector3[] { camera.transform.position , fangjian2Position },1)
                .SetEase(Ease.OutQuad)
                 .OnComplete(
            () =>
            {
                //TODO:失活上一个场景物体
                bingxiang.SetActive(false);
                Door1.SetActive(false);
                //TODO:激活UI物体
                Door2.SetActive(true);

            }
            );
        
    }
    public void YidongcameraTo3()
    {
        
            Vector3 fangjian3Position = fangjian3.position;
            fangjian3Position.z = -10;
            camera.transform.DOPath(new Vector3[] { camera.transform.position , fangjian3Position },1)
                .SetEase(Ease.OutQuad)
                 .OnComplete(
            () =>
            {
                //TODO:失活上一个场景物体
                Door2.SetActive(false);
                //TODO:激活UI物体
                Door3.SetActive(true);
            }
            );
        
    }
    public void YidongcameraTo4()
    {
        
            Vector3 fangjian4Position = fangjian4.position;
            fangjian4Position.z = -10;
            camera.transform.DOPath(new Vector3[] { camera.transform.position , fangjian4Position },1)
                .SetEase(Ease.OutQuad)
                 .OnComplete(
            () =>
            {
                //TODO:失活上一个场景物体
                Door3.SetActive(false);
                //TODO:激活UI物体
                Door4.SetActive(true);

            }
            );
        
    }
    public void YidongcameraTo5()
    {
        
            Vector3 fangjian5Position = fangjian5.position;
            fangjian5Position.z = -10;
            camera.transform.DOPath(new Vector3[] { camera.transform.position , fangjian5Position },1)
                .SetEase(Ease.OutQuad)
                 .OnComplete(
            () =>
            {
                //TODO:失活上一个场景物体
                Door4.SetActive(false);
                //TODO:激活UI物体

            }
            );
        
    }
}
