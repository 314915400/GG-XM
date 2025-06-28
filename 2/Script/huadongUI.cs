using UnityEngine;
using UnityEngine.UI;

public class huadongUI : MonoBehaviour
{
    public Image have;
    public Image kong;
    private double zhanbi;
    public Transform button;
    private void Update()
    {
        Change();
    }
    public void Change()
    {
        zhanbi = (button.position.x - 463.7) / 143.9;
        have.fillAmount = (float)zhanbi;
    }
}
