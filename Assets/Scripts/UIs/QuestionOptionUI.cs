using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionOptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private QuestionData questionData;
    [SerializeField] private int orderIndex;

    private void Setup()
    {
        optionText.text = questionData.name;
    }
}
