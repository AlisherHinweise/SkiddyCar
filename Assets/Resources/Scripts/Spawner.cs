using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float time = 0;

    [SerializeField] private ParticleSystem _driftParticles;
    [SerializeField] private Transform _leftWheel;
    [SerializeField] private Transform _rightWheel;

    private Transform _currentLeftWheel;
    private Transform _currentRightWheel;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnPrefabs());
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(SpawnPrefabs());
        }
    }

    IEnumerator SpawnPrefabs()
    {
        int i = 0;
        while (i <= 6)
        {
            GetWheelsPostion(_leftWheel, _rightWheel);
            Instantiate(_driftParticles, _currentRightWheel.position, Quaternion.Euler(0, 90, 0), gameObject.transform);
            Instantiate(_driftParticles, _currentLeftWheel.position, Quaternion.Euler(0, 90, 0), gameObject.transform);
            yield return new WaitForSeconds(0.12f);
            i++;
        }
    }

    private void GetWheelsPostion(Transform _leftWheel, Transform _rightWheel)
    {
        Debug.Log(_leftWheel.position);
        _currentLeftWheel = _leftWheel;
        _currentRightWheel = _rightWheel;
    }
}
