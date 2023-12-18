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
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Lock Configs")]
    [SerializeField] private bool isLocked;
    [SerializeField] private Image lockImage;
    [SerializeField] private Color lockedColor;
    [SerializeField] private Color unlockedColor;



    // Event Management
    public static event System.Action<LevelPack, bool> OnClick;


    private void Start()
    {
        SubscribeEvents();
    }

    public void Setup(LevelPack levelPack)
    {
        this.levelPack = levelPack;
        optionText.text = levelPack.name;
        priceText.text = levelPack.GetPrice().ToString();
    }

    public void Lock()
    {
        isLocked = true;

        var priceTextParent = priceText.transform.parent;
        priceTextParent.gameObject.SetActive(true);

        var buttonColors = button.colors;
        buttonColors.normalColor = lockedColor;
    }

    public void Unlock()
    {
        isLocked = false;
        lockImage.gameObject.SetActive(false);

        var priceTextParent = priceText.transform.parent;
        priceTextParent.gameObject.SetActive(false);

        var buttonColors = button.colors;
        buttonColors.normalColor = unlockedColor;
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
        OnClick?.Invoke(levelPack, isLocked);
    }
}
