using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text timerText;
    public int finalScore;


    private Rigidbody rb;
    private int count;
    private float startTimer;
 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        SetCurrentTime(); 
        winText.text = "";
        startTimer = Time.time;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (count != finalScore)
        {
            SetCurrentTime();
        }
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= finalScore)
        {
            winText.text = "You Win!";
        }
    }
    void SetCurrentTime()
    {
        float t = Time.time - startTimer;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString();

        timerText.text = minutes + ":" + seconds;
    }
}