using UnityEngine;

public class bingxiang : MonoBehaviour
{
    public GameObject bingxiangPrefab;
    public void OnButton()
    {
        bingxiangPrefab.SetActive(true);
        Destroy(bingxiangPrefab,20);
    }
}
