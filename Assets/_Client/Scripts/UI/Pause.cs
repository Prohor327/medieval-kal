using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Pause : UIToolkit
{
    [SerializeField] private GameUI _gameUI;

    protected override void Initialize()
    {
        Button Continue = UIElement.Q<Button>("Continue");
        Button Exit = UIElement.Q<Button>("Exit");

        Continue.clicked += () => {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;  
            Time.timeScale = 1;
            _gameUI.OpenUI();
        };
        Exit.clicked += () => SceneManager.LoadScene(0);
        base.Initialize();
    }

    protected override void Open()
    {
        Time.timeScale = 0;
        base.Open();
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void OpenPause()
    {
        Open();
    }
}
