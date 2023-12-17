using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class LevelPackOptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private LevelPack levelPack;
    [SerializeField] private Button button;

    // Event Management
    public static event System.Action<LevelPack> OnClick;


    private void Start()
    {
        SubscribeEvents();
    }

    public void Setup(LevelPack levelPack)
    {
        this.levelPack = levelPack;
        optionText.text = levelPack.name;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        button.onClick.AddListener(Click);
    }
    private void UnsubscribeEvents()
    {
        print("button is " + button);
        button.onClick.RemoveListener(Click);
    }


    private void Click()
    {
        OnClick?.Invoke(levelPack);
    }
}
