using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class Death : UIToolkit
{
    protected override void Initialize()
    {
        Button restart = UIElement.Q<Button>("Restart");
        Button exit = UIElement.Q<Button>("Exit");

        restart.clicked += () => SceneManager.LoadScene(1);
        exit.clicked += () => SceneManager.LoadScene(0);
    }

    protected override void Open()
    {
        base.Open();
    }

    public void DeathPlayer() => Open();
}
