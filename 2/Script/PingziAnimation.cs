using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PingziAnimation : MonoBehaviour
{
    public GameObject pingziyuzhiti;
    private void Awake()
    {

    }
    private void Update()
    {

    }
    public void Jinxingjiaoshui()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;
        GameObject go= GameObject.Instantiate(pingziyuzhiti, MousePosition, Quaternion.identity);
    }

    public void OnMouseDown()
    {
        Jinxingjiaoshui();
    }
}
