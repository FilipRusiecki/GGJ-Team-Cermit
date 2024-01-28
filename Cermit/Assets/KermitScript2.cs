using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class KermitScript2 : MonoBehaviour
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

    //public int lives = 3;
    //   public bool takelife = true;
    Vector2 savedlocalScale;
    public float playerSpeed;
    Quaternion lookQuaternion;
    [Header("trolling")]
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;
    public GameObject obj8;
    public GameObject obj9;
    public GameObject obj10;
    public GameObject obj11;
    public GameObject obj12;

    public int rand;


    [Header("lights")]
    public Light2D light1;
    public Light2D light2;
    public Light2D light3;
    public Light2D light4;
    public Light2D light5;
    public Light2D light6;
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;
    Color color2 = Color.green;
    Color color3 = Color.yellow;
    Color color4 = Color.cyan;
    Color color5 = Color.magenta;

    public bool hp = false;
    [Header("anims")]
    public Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        savedlocalScale = transform.localScale;

    }
    // Update is called once per frame
    void Update()

    {    ////////////////////////////////////////////////////////////////////////////            <<--------- scale rot
        float t = Mathf.PingPong(Time.time, duration) / duration;
        if (hp == true)
        {
            light1.color = Color.Lerp(color0, color1, t);
            light2.color = Color.Lerp(color2, color3, t);
            light3.color = Color.Lerp(color4, color5, t);
            light4.color = Color.Lerp(color0, color1, t);
            light5.color = Color.Lerp(color2, color3, t);
            light6.color = Color.Lerp(color4, color5, t);

        }


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

        if (rb.velocity.x > 0.001f)
        {
            animator.SetBool("movin", true);
        }
        else if (rb.velocity.x < -0.001f)
        {
            animator.SetBool("movin", true);
        }
        else
        {
            animator.SetBool("movin", false);

        }

        ////////////////////////////////////////////////////////////////////////////



    }

    //IEnumerator takelives()
    //{
    //    takelife = false;
    //    lives--;
    //    transform.position = new Vector2(0f, -0.619f);
    //    yield return new WaitForSeconds(1.0f);
    //    takelife = true;
    //}
    ////////////////////////////////////////////////////////////////////////////      
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("dwayne"))
        {
            transform.position = new Vector2(-18f, -14f);
            StartCoroutine(boomboom());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rockS"))
        {
            obj1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("dwayne"))
        {
            SceneManager.LoadScene("game2");
        }
        if (collision.gameObject.CompareTag("killS"))
        {
            obj2.SetActive(true);
        }
        if (collision.gameObject.CompareTag("spikeS1"))
        {
            obj3.SetActive(true);
        }
        if (collision.gameObject.CompareTag("death"))
        {
            transform.position = new Vector2(-18f, -14f);
            StartCoroutine(boomboom());
        }
        if (collision.gameObject.CompareTag("dss"))
        {
            obj4.SetActive(true);
            obj5.SetActive(true);
            obj6.SetActive(true);
        }
        if (collision.gameObject.CompareTag("hp"))
        {
            hp = true;
        }
        if (collision.gameObject.CompareTag("load2"))
        {
            SceneManager.LoadScene("loading 2");
        }
    }
    IEnumerator boomboom()
    {
        obj11.SetActive(true);

        rand = Random.Range(0, 4);
        rb.gravityScale = 0;
        if (rand == 0)
        {
            obj7.SetActive(true);
        }
        if (rand == 1)
        {
            obj8.SetActive(true);
        }
        if (rand == 2)
        {
            obj9.SetActive(true);
        }
        if (rand == 3)
        {
            obj10.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("game2");
    }
}