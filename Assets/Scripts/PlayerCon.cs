using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCon : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    public AudioClip burgerSound;
    public AudioClip winSound;
//    public AudioClip loseSound;

    private Rigidbody2D rb;
    private int count;
    private Vector2 moveVelocity;

    public GameObject restartButton;
    
    //public GameOverScreen GameOverScreen;


    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
    }

    void SetCountText()
    {
        countText.text = "Burgers Eaten: " + count.ToString();
        if(count >= 5)
        {
            winTextObject.SetActive(true);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            restartButton.SetActive(true);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("burger"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            AudioSource.PlayClipAtPoint(burgerSound, transform.position);

            SetCountText();
        }
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
