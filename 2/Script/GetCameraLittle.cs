using UnityEngine;
using DG.Tweening;
using System.Drawing;
public class GetCameraLittle : MonoBehaviour
{
    public Camera camera;
    public Transform fangjian;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        GetLittle();
    }
    private void Update()
    {
        if (camera.orthographicSize>3.29)
        camera.orthographicSize -= Time.deltaTime * 10;
    }
    public void GetLittle()
    {
        Vector3 fangjianPosition= fangjian.position;
        fangjianPosition.z = -10;
        camera.transform.DOPath(new Vector3[] { camera.transform.position, fangjianPosition,}, 1)
            .SetEase(Ease.OutQuad)
             .OnComplete(
            () =>
            {
                //TODO:º§ªÓUIŒÔÃÂ

            }
            );

    }
}
