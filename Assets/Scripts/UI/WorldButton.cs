using Mono.Cecil.Cil;
using UnityEngine;

public class WorldButton : MonoBehaviour
{
    enum ButtonType
    {
        Start,
        Options,
        Exit
    }
    [SerializeField] ButtonType buttonType;

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
        Debug.Log("pressed start btn");
    }

    void OptionsBtn()
    {
        Debug.Log("pressed options btn");
    }

    void ExitBtn()
    {
        Application.Quit();
        Debug.Log("Application QUIT");
    }
}
