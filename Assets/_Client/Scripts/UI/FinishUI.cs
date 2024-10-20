using UnityEngine;
using UnityEngine.UIElements;

public class FinishUI : UIToolkit 
{
    protected override void Initialize()
    {
        Button exit = UIElement.Q<Button>("Exit");

        exit.clicked += () =>
        {
            Player.Instance.DestroyPlayer();
            SceneLoader(0);
        };
    }

    protected override void Open()
    {
        base.Open();
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }
    public void OpenUI()
    {
        Open();
    }
}