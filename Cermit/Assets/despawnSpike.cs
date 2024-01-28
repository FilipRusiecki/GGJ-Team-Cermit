using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnSpike : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject o;
    void Start()
    {
        StartCoroutine(boomboom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator boomboom()
    {
        yield return new WaitForSeconds(3.0f);
        o.SetActive(true);
        Destroy(this.gameObject);
    }
}
