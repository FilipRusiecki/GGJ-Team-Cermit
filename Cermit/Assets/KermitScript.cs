using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KermitScript : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////            <<--------- variables
   
    [Header("Player stuff")]
    public Rigidbody2D rb;
    public float jumpForce = 0;
    public int jumpCount = 0;
    public int allowedJumps = 0;
    public float gravityScale = 0;
    public float fallingGravityScale = 0;
    public bool isGrounded = false;
    public bool m_FacingRight = true;
    public bool m_FacingLeft = false;

    public int lives = 3;
    public bool takelife = true;
    Vector2 savedlocalScale;
    public float playerSpeed;
    Quaternion lookQuaternion;
    [Header("trolling")]
    public GameObject obs1;
    public GameObject obs2;
    public GameObject obs3;
    public GameObject obs4;
    public GameObject obs5;
    public GameObject obs6;
    public GameObject obs7;
    public GameObject obs8;
    public GameObject obs9;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savedlocalScale = transform.localScale;
      
    }
    // Update is called once per frame
    void Update()
    {    ////////////////////////////////////////////////////////////////////////////            <<--------- scale rot
        if (rb.velocity.x > 0.001f)
        {
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = false;
            m_FacingRight = true;
        }
        else if (rb.velocity.x < -0.001f)
        {
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);

            m_FacingLeft = true;
            m_FacingRight = false;
        }

        ////////////////////////////////////////////////////////////////////////////            <<--------- movement
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        if (lives == 3)
        {
            obs1.SetActive(true);
            obs3.SetActive(false);

        }
        if (lives == 2)
        {
            obs1.SetActive(false);
            obs2.SetActive(true);
            obs3.SetActive(true);
            obs8.SetActive(true);

        }
        if (lives == 1)
        {
            obs5.SetActive(false);
            obs6.SetActive(true);
            obs9.SetActive(true);
        }

        //if (Input.GetKey(KeyCode.A))
        //{       //when a pressed move left
        //    animator.SetFloat("speed", Mathf.Abs(playerSpeed));
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{       //when d pressed move right
        //    animator.SetFloat("speed", Mathf.Abs(playerSpeed));
        //}
        //else
        //{
        //    animator.SetFloat("speed", Mathf.Abs(0));
        //}

        ////////////////////////////////////////////////////////////////////////////            <<--------- jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           // animator.SetBool("isJumping", true);
          //  GameObject jumpsParticles = Instantiate(jumpParticle, rb.transform.position, lookQuaternionJump);
          //  Destroy(jumpsParticles, 2.0f);
            jumpCount += 1;
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        ////////////////////////////////////////////////////////////////////////////


      
    }

    IEnumerator takelives()
    {
        takelife = false;
        lives--;
        transform.position = new Vector2(0f, -0.619f);
        yield return new WaitForSeconds(1.0f);
        takelife = true;
    }
    ////////////////////////////////////////////////////////////////////////////      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            StartCoroutine(takelives());
        }
        if (collision.gameObject.CompareTag("load1"))
        {
            SceneManager.LoadScene("loading 1");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nowj"))
        {
            obs4.SetActive(true);
        }
        if (collision.gameObject.CompareTag("wtf"))
        {
            obs7.SetActive(true);
        }
    }
}