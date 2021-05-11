using UnityEngine;
using UnityEngine.SceneManagement;

public class park_ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}