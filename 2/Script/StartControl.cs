using UnityEngine;
using UnityEngine.SceneManagement;

public class StartControl : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnPeopleButton()
    {
        SceneManager.LoadScene(2);
    }
}
