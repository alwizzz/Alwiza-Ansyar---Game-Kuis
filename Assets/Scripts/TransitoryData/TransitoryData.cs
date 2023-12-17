using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "TransitoryData",
    menuName = "QuizGame/TransitoryData"
)]
public class TransitoryData : ScriptableObject
{
    public LevelPack currentLevelPack;
    public int currentQuestionIndex;
}
