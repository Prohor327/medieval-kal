using UnityEngine.UIElements;
using System.Collections;
using UnityEngine;

public class Death : UIToolkit
{
    [SerializeField] private Player _player;

    public bool _death;
    private float _i;

    protected override void Initialize()
    {
        Button restart = UIElement.Q<Button>("Restart");
        Button exit = UIElement.Q<Button>("Exit");

        restart.clicked += () =>
        {
            _player.DestroyPlayer();
            SceneLoader(1);
        };
        exit.clicked += () =>
        {
            _player.DestroyPlayer();
            SceneLoader(0);
        };
        _death = false;
    }

    protected override void Open()
    {
        base.Open();
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        _death = true;
    }

    public void DeathPlayer() => StartCoroutine("ShowConteiner");

    IEnumerator ShowConteiner()
    {
        yield return new WaitForSeconds(2.7f);
        Open();
        StopCoroutine(ShowConteiner());
    }
}
