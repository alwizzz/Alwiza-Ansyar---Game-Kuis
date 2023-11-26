using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private bool isCorrect;

    [SerializeField] private FlashMessage flashMessage;

    public void SetAnswerOption(string answerString, bool isCorrect)
    {
        answerText.text = answerString;
        this.isCorrect = isCorrect;
    }

    public void Choose()
    {
        //print($"Jawaban anda adalah {answerText.text} ({isCorrect})");
        flashMessage.Message = $"Jawaban anda adalah {answerText.text} ({isCorrect})";

    }
}
