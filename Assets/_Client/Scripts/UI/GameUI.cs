using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : UIToolkit
{
    [SerializeField] private Pause _pause;

    private ProgressBar _hpBar;
    private ProgressBar _stamina;
    private bool _paused = false;

    protected override void Initialize()
    {
        InitializeUI(100, 100);
        base.Initialize();
    }

    public void OpenUI()
    {
        Open();
    }

    private void InitializeUI(float maxHealth, float maxStamina)
    {
        _hpBar = UIElement.Q<ProgressBar>("Health");
        _stamina = UIElement.Q<ProgressBar>("Stamina");

        _hpBar.lowValue = 0;
        _hpBar.highValue = maxHealth;
        _hpBar.title = _hpBar.highValue.ToString() + "/" + _hpBar.highValue.ToString();
        _stamina.lowValue = 0;
        _stamina.highValue = maxStamina;
        _stamina.title = _stamina.highValue.ToString() + "/" + _stamina.highValue.ToString();
    }

    public void UpdateHealthBarValue(float value)
    {
        UpdateProgressBarWithTitle(value, _hpBar);
    }

    public void UpdateStaminahBarValue(float value)
    {
        UpdateProgressBarWithTitle(value, _stamina);
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
