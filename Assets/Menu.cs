using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
}
