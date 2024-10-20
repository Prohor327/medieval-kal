using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private FinishUI _finish;

    private void OnTriggerEnter(Collider other) 
    {
        _finish.OpenUI();
    }
}
