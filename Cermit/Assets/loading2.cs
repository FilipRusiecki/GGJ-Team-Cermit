using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loading2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadingS());
    }

    IEnumerator loadingS()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("game3");
    }
}
