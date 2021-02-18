using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Text _count;
    private int _coinsCount = 0;

    public void AddCoin()
    {
        _coinsCount++;
        Debug.Log(_coinsCount);
        _count.text = _coinsCount.ToString();
    }
}
