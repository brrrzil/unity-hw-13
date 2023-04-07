using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 distance;
    [SerializeField] private Transform hero;

    void Start()
    {
        distance = transform.position - hero.position;
    }

    void Update()
    {
        if (hero != null) transform.position = hero.position + distance;
    }
}
