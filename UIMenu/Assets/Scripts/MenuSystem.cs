using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[System.Serializable]
public class MenuEntry
{
    public string EntryName;
    public UnityEvent Callback;
}

[RequireComponent(typeof(UIDocument))]
public class MenuSystem : MonoBehaviour
{
    [SerializeField] private List<MenuEntry> _menuEntries;
    [SerializeField] private float _transitionDuration;
    [SerializeField] private EasingMode _easing;
    [SerializeField] private float _buttonDelay;
    [SerializeField] private VisualTreeAsset _buttonTemplate;
    private VisualElement _container;
    private WaitForSeconds _pause;
    
    private void Start()
    {
        _pause = new WaitForSeconds(_transitionDuration);
        StartCoroutine(CreateMenu());
    }

    private IEnumerator CreateMenu()
    {
        _container = GetComponent<UIDocument>().rootVisualElement.Q<VisualElement>("container");

        foreach (var menuEntry in _menuEntries)
        {
            VisualElement visualElement = _buttonTemplate.CloneTree();
            Button button = visualElement.Q<Button>("menu-button");
            button.text = menuEntry.EntryName;
            button.clicked += delegate { OnClick(menuEntry); };
            _container.Add(visualElement);
            yield return _pause;
        }
    }

    private void OnClick(MenuEntry entry)
    {
        Debug.Log("Наджата кнопка " + entry.EntryName);
    }
}
