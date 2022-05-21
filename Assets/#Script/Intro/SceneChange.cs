using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

}
