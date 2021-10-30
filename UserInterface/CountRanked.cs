using System;
using UnityEngine;
using UnityEngine.UI;

public class CountRanked : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private string _formater;

    private int _score;

    private void OnEnable()
    {
        EventHandler.Score += ONChangeRank;       
    }

    private void OnDisable()
    {
        EventHandler.Score -= ONChangeRank;
    }
    private void ONChangeRank(int score)
    {
        _score += score;
        _text.text = $"{_formater} : {_score}";
    }

   
}
