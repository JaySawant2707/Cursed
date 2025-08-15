using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldButton : MonoBehaviour
{
    enum ButtonType
    {
        Start,
        Options,
        Exit
    }

    [SerializeField] ButtonType buttonType;

    [SerializeField] GameObject optionsScreen;

    public void OnClickWorldButton()
    {
        switch (buttonType)
        {
            case ButtonType.Start:
                StartBtn();
                break;
            case ButtonType.Options:
                OptionsBtn();
                break;
            case ButtonType.Exit:
                ExitBtn();
                break;
            default:
                break;
        }
    }

    void StartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OptionsBtn()
    {
        optionsScreen.SetActive(true);
    }

    void ExitBtn()
    {
        Application.Quit();
        Debug.Log("Band ho gaya");
    }

    public void BackBtn()
    {
        optionsScreen.SetActive(false);
    }
}
