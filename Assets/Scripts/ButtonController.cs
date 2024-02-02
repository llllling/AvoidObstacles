using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public void OnStart()
    {
        SoundControll.instance.PlayButton();
        SceneManager.LoadScene("MainScene");
    }

    public void OnClose()
    {
        SoundControll.instance.PlayButton();
    }

    public void OnSound()
    {
        bool isSoundOn = !SoundControll.instance.isSoundOn;
        SoundControll.instance.isSoundOn = isSoundOn;
        SoundControll.instance.gameObject.SetActive(isSoundOn);

        Image image = GetComponent<Image>();
        if (isSoundOn)
        {
            image.color = Color.white;
        } else
        {
            image.color = Color.gray;
        }
    }
}
