using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool isOpenInfo = false;
    public void OnStart()
    {
        SoundControll.instance.PlayButton();
        SceneManager.LoadScene("MainScene");
    }

    public void OnSound()
    {
        bool isSoundOn = !SoundControll.instance.isSoundOn;
        SoundControll.instance.isSoundOn = isSoundOn;
        SoundControll.instance.gameObject.SetActive(isSoundOn);

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
