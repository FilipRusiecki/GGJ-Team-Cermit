using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loading1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadingS());
    }

    IEnumerator loadingS()
    {
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("game1");
    }
}
