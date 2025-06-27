using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public void OnButton()
    {
        SceneManager.LoadScene(3);
    }
}
