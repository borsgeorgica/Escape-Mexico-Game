using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 600f;
    public Transform groundCheck;
    
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    private int numberOfBullets;
    private int numberOfCollectibles;
    private int numberOfLives;

    public Text livesText;
    public Text collectiblesText;
    public Text bulletsText;

    public float bulletSpeed = 300f;
    public float shootRate = 2f;
    private float deltaTime = 0;

    public GameObject bullet;

    private Vector3 startPosition;


    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        numberOfBullets = 3;
        numberOfCollectibles = 0;
        numberOfLives = 3;
        SetCountText();
        startPosition = transform.position;
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            numberOfCollectibles = numberOfCollectibles + 1;
            if (numberOfCollectibles == 5)
            {
                numberOfBullets++;
                numberOfCollectibles = 0;
            }
                
        }
        if (other.gameObject.CompareTag("Death"))
        {
            //SceneManager.LoadScene(1);

            numberOfLives -= 1;
            if(numberOfLives<=0)
            {
                //Finish the game - YOu didn;t cross the border Sorry
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                transform.position = startPosition;
            }

        }
            

    }

    void SetCountText()
    {
        livesText.text = "Lives left: " + numberOfLives.ToString();
        collectiblesText.text = "Collectibles: " + numberOfCollectibles.ToString();
        bulletsText.text = "Bullets: " + numberOfBullets.ToString();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
		
	}
    

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (h > 0 && !facingRight)
        {
            facingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (h < 0 && facingRight)
        {
            facingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;

        }
        SetCountText();
        if (Time.time >= deltaTime && Input.GetMouseButton(0))
        {
            anim.SetTrigger("Shoot");
            Vector2 gunPos = new Vector2(transform.position.x + 2, transform.position.y);
            GameObject bulletInst;
            bulletInst = Instantiate(bullet, gunPos, Quaternion.identity);
            bulletInst.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.right * bulletSpeed);
            deltaTime = Time.time + shootRate;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
