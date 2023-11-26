using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    public string Message
    {
        get => messageText.text;
        set => messageText.text = value;
    }


    private void Awake()
    {
        if (gameObject.activeSelf) { gameObject.SetActive(false); }
    }
}
