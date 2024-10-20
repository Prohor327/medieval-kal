using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIToolkit
{
    [SerializeField] private Pause _pause;

    private ProgressBar _hpBar;

    protected override void Initialize()
    {
        Player.Instance.hitBox.OnTakeDamage += UpdateHealthBarValue;
        InitializeUI(Player.Instance.hitBox.maxHealth, 10);
        base.Initialize();
    }

    public void OpenUI()
    {
        Open();
    }

    private void InitializeUI(float maxHealth, float maxStamina)
    {
        _hpBar = UIElement.Q<ProgressBar>("Health");

        _hpBar.lowValue = 0;
        _hpBar.highValue = maxHealth;
        _hpBar.title = _hpBar.highValue.ToString() + "/" + _hpBar.highValue.ToString();
    
    }

    public void UpdateHealthBarValue(float value)
    {
        UpdateProgressBarWithTitle(value, _hpBar);
    }


    private void UpdateProgressBarWithTitle(float value, ProgressBar progressBar)
    {
        progressBar.value = value;
        progressBar.title = Math.Round((decimal)progressBar.value, 2).ToString() + "/" + progressBar.highValue.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _pause.OpenPause();
        }
    }
}
