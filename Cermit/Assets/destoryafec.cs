using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destoryafec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(boomboom());
    }

    IEnumerator boomboom()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
