using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    private void ChangeScene()
    { 
        SceneManager.LoadScene(nextSceneName);
    }
}
