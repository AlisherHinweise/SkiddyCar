using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _coinsPosition;
    [SerializeField] private GameObject _coins;
    public Transform end;
    public Transform begin;

    private void Start()
    {
        if(Random.Range(0, 100) > 25)
        {
            Instantiate(_coins, _coinsPosition);
        }
    }
}
