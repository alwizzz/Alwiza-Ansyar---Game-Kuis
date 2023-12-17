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
    public static event System.Action<LevelPack> OnClickingLevelPackOptionButton;

    private void Awake()
    {
        /* 
         * saya prefer mendapatkan komponen button menggunakan GetComponent
         * karena semua gameobject dari script ini adalah sebuah UI Button
         */

        button = GetComponent<Button>();
    }

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
        button.onClick.RemoveListener(Click);
    }


    private void Click()
    {
        OnClickingLevelPackOptionButton?.Invoke(levelPack);
    }
}
