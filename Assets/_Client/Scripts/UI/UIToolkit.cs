using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public abstract class UIToolkit : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _UIAsset;

    private VisualElement _doc;

    protected VisualElement UIElement;

    private void OnEnable()
    {
        _doc = GetComponent<UIDocument>().rootVisualElement;
    }

    private void Start()
    {
        UIElement = _UIAsset.CloneTree();
        Initialize();
    }

    protected virtual void Initialize() 
    {
        Open();
    }

    protected virtual void Open()
    {
        _doc.Clear();
        _doc.Add(UIElement);
    }

    protected void SceneLoader(int index)
    {
        SceneManager.LoadScene(index);
    }
}
