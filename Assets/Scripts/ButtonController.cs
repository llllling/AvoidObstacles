using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip StartBtnSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void OnStart()
    {
        audioSource.PlayOneShot(StartBtnSound);
        SceneManager.LoadScene("MainScene");
    }
}
