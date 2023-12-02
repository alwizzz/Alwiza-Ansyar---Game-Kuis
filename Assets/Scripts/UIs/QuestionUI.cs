using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI questionText;

    [SerializeField] private Image hintImage;

    public void SetQuestion(string titleString, string questionString, Sprite hintSprite)
    {
        titleText.text = titleString;
        questionText.text = questionString;
        hintImage.sprite = hintSprite;
    }
}
