using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Pause : UIToolkit
{
    protected override void Initialize()
    {
        Button Continue = UIElement.Q<Button>("Continue");
        //Button Control = UIElement.Q<Button>("Control");
        Button Exit = UIElement.Q<Button>("Exit");

        Continue.clicked += () => Time.timeScale = 1;
        //Control.clicked += () => 
        Exit.clicked += () => SceneManager.LoadScene(0);
        base.Initialize();
    }

    protected override void Open()
    {
        Time.timeScale = 0;
        base.Open();
    }
}
