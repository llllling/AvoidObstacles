using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
