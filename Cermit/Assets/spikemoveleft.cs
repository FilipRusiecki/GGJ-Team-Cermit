using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikemoveleft : MonoBehaviour
{
    public float speed;
    public GameObject o;
    void Start()
    {
        StartCoroutine(boomboom());
    }
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    IEnumerator boomboom()
    {
        yield return new WaitForSeconds(3.0f);
        o.SetActive(true);
        Destroy(this.gameObject);
    }
}
