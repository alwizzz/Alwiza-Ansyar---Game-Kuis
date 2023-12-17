using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelPackOptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private LevelPack levelPack;

    private void Start()
    {
        if(levelPack == null) { return; }

        Setup();
    }

    private void Setup()
    {
        optionText.text = levelPack.name;
    }
}
