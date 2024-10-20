using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {
    public void FinishScene()
    {
        SceneManager.LoadScene(02);
    }
}