using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
