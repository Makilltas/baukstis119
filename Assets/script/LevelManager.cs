using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        var levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
    }
}
