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
