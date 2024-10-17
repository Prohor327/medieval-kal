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

        Continue.clicked += ClosePause;
        Exit.clicked += () => SceneManager.LoadScene(0);
    }

    protected override void Open()
    {
        base.Open();
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        Open();
    }

    private void ClosePause()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        Time.timeScale = 1;
        _gameUI.OpenUI();
    }
}
