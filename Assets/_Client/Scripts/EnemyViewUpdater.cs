using UnityEngine;
using System;

public class EnemyViewUpdater : MonoBehaviour 
{
    public Action OnFinishAttack;

    public void UpdateView()
    {
        OnFinishAttack.Invoke();
    }
}