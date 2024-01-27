using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCollision : MonoBehaviour
{
    public KermitScript player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            player.isGrounded = true;
            player.jumpCount = 0;
          //  player.animator.SetBool("isJumping", false);
        }
    }



}