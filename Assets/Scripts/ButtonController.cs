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
    }

    public void OnRestart()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.Clear();
    }
    public void OnLoadIntro()
    {
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("IntroScene");
        GameManager.Instance.Clear();
    }

    public void OnSound()
    {
        bool isSoundOn = !SoundManager.Instance.isSoundOn;
        SoundManager.Instance.isSoundOn = isSoundOn;
        SoundManager.Instance.gameObject.SetActive(isSoundOn);

        Image image = GameObject.Find("SoundButton").GetComponent<Image>();
        if (isSoundOn)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.gray;
        }
    }

    public void OnInfomation(bool isOpen)
    {
        isOpenInfo = isOpen;

        GameObject.FindObjectOfType<Canvas>().transform.Find("Infomation").gameObject.SetActive(isOpenInfo);
    }
}
