using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIToolkit
{
    protected override void Initialize()
    {
        Button play = UIElement.Q<Button>("Play");
        Button exit = UIElement.Q<Button>("Exit");

        play.clicked += () => SceneLoader(1);
        exit.clicked += Application.Quit;
        base.Initialize();
    }
}
