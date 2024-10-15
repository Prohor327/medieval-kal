using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : UIToolkit
{
    protected override void Initialize()
    {
        Button play = UIElement.Q<Button>("Play");
        Button exit = UIElement.Q<Button>("Exit");

        play.clicked += () => SceneManager.LoadScene(1);
        exit.clicked += Application.Quit;
        base.Initialize();
    }
}
