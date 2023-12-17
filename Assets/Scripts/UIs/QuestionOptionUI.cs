using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class QuestionOptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private QuestionData questionData;
    [SerializeField] private int orderIndex;
    [SerializeField] private Button button;

    // Event Management
    public static event System.Action<int> OnClick;

    private void Start()
    {
        /* 
         * saya prefer mendapatkan komponen button menggunakan GetComponent
         * karena semua gameobject dari script ini adalah sebuah UI Button
         */
        button = GetComponent<Button>();

        SubscribeEvents();
    }

    public void Setup(QuestionData data)
    {
        questionData = data;
        optionText.text = data.name;
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
        OnClick?.Invoke(questionData.index);
    }
}
