using UnityEngine;
using UnityEngine.SceneManagement;

public class StartControl : MonoBehaviour
{
    public void OnButton()
    {
        SceneManager.LoadScene(1);
    }
}
