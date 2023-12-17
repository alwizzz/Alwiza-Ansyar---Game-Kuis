using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUI : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float counter;
    [SerializeField] private bool timeIsRunning;
    [SerializeField] public bool TimeIsRunning
    {
        get => timeIsRunning;
        set => timeIsRunning = value;
    }

    [SerializeField] private Slider timerSlider;
    //[SerializeField] private FlashMessageUI flashMessage;

    // Event Management
    public static event System.Action OnTimeRunsOut;


    private void Start()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        counter = duration;
        timeIsRunning = true;
    }

    private void Update()
    {
        if (!timeIsRunning) { return; }

        counter -= Time.deltaTime;
        timerSlider.value = counter / duration;

        if(counter <= 0f)
        {
            timeIsRunning = false;
            counter = 0f;

            //flashMessage.Message = "Waktu habis!";
            //flashMessage.gameObject.SetActive(true);

            OnTimeRunsOut?.Invoke();
        }
    }
}
