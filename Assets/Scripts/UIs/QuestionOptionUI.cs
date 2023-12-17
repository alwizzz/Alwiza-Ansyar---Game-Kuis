using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionOptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private QuestionData questionData;
    [SerializeField] private int orderIndex;

    public void Setup(QuestionData data)
    {
        questionData = data;
        optionText.text = data.name;
    }
}
