using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashMessageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject buttonsOnCorrectAnswer;
    [SerializeField] private GameObject buttonsOnWrongAnswer;


    public string Message
    {
        get => messageText.text;
        set => messageText.text = value;
    }


    private void Awake()
    {
        if (gameObject.activeSelf) { gameObject.SetActive(false); }
        SubscribeEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        TimerUI.OnTimeRunsOut += ShowTimeRunsOutMessage;
        AnswerOptionUI.OnChoosingAnswer += ShowAnswerResultMessage;
    }
    private void UnsubscribeEvents()
    {
        TimerUI.OnTimeRunsOut -= ShowTimeRunsOutMessage;
        AnswerOptionUI.OnChoosingAnswer -= ShowAnswerResultMessage;
    }

    private void ShowTimeRunsOutMessage()
    {
        Message = "Waktu Habis";
        gameObject.SetActive(true);
    }

    private void ShowAnswerResultMessage(string answer, bool isCorrect)
    {
        Message = $"Jawaban anda {(isCorrect ? "benar" : "salah")}! ({answer})";


        if(isCorrect)
        {
            buttonsOnCorrectAnswer.SetActive(true);
            buttonsOnWrongAnswer.SetActive(false);
        } else
        {
            buttonsOnCorrectAnswer.SetActive(false);
            buttonsOnWrongAnswer.SetActive(true);
        }


        gameObject.SetActive(true);
    }
}
