using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool isOpenInfo = false;
    public void OnStart()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("MainScene");
        SoundManager.Instance.ReplayBGM();
    }

    public void OnRestart()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.Clear();
        SoundManager.Instance.ReplayBGM();
    }
    public void OnLoadIntro()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("IntroScene");
        GameManager.Instance.Clear();
        SoundManager.Instance.ReplayBGM();
    }

    public void OnSound()
    {
        bool isMute = !SoundManager.Instance.isMute;
        SoundManager.Instance.isMute = isMute;
        SoundManager.Instance.Mute(isMute);

        Image image = GameObject.Find("SoundButton").GetComponent<Image>();
        if (isMute)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }

    public void OnInfomation(bool isOpen)
    {
        isOpenInfo = isOpen;

        GameObject.FindObjectOfType<Canvas>().transform.Find("Infomation").gameObject.SetActive(isOpenInfo);
    }
}
