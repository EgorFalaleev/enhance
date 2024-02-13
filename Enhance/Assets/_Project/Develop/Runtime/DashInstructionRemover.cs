using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashInstructionRemover : MonoBehaviour
{
    [SerializeField] private float _timeTillDisable = 10f;
    private float _timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeTillDisable)
            gameObject.SetActive(false);
    }
}
