using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Text message;
    private int _maxCountStones=10;
    private bool _onGenerate;
    private int _currentCountStones = 0;
    private int _timeRespwanStone = 15;

    void OnEnable()
    {
        _onGenerate = true;
        StartCoroutine(GenerateStone());
    }

    private IEnumerator GenerateStone()
    {
        while (_onGenerate)
        {
            if (_currentCountStones < _maxCountStones)
            {
                var obj = Instantiate(stonePrefab, new Vector3(Random.Range(-95f, 95f), 1, Random.Range(-95f, 95f)),
                    Quaternion.identity, transform);
                obj.GetComponent<Stone>().OnDestroy += DestroyStone;
                _currentCountStones++;
            }
            yield return new WaitForSecondsRealtime(_timeRespwanStone);
        }
    }

    private void DestroyStone()
    {
        message.text = "";
        _currentCountStones--;
    }

    public void LoadStones(List<Vector3> positionStones)
    {
        foreach (var positionStone in positionStones)
        {
            var obj = Instantiate(stonePrefab, positionStone,
                Quaternion.identity, transform);
            obj.GetComponent<Stone>().OnDestroy += DestroyStone;
            _currentCountStones++;
        }
    }

    private void OnDisable()
    {
        _onGenerate = false;
    }
}
