using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Player;
    public float speed = 1000f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;
    public Joystick moveJoystick;
    Vector3 translateObj;
    Vector3 rotateObj;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health == 0)
        {
            winLoseText.color = Color.white;
            winLoseText.text = $"Game Over!";
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchSupported)
        {
            // Active the Touch option for device
            moveJoystick.gameObject.SetActive(true);
            // Get the value of the X and Z input axis for movement.
            translateObj.x = moveJoystick.Horizontal;// Horizontal
            translateObj.z = moveJoystick.Vertical;// Vertical
            // Invert the Axis => move in X rotate in Z
            rotateObj.x = moveJoystick.Vertical;// Vertical
            rotateObj.z = moveJoystick.Horizontal;// Horizontal
        }
        else
        {
            moveJoystick.gameObject.SetActive(false);
            // Get the value of the X and Z input axis for movement.
            translateObj.x = Input.GetAxis("Horizontal");
            translateObj.z = Input.GetAxis("Vertical");
            // Invert the Axis => move in X rotate in Z
            rotateObj.x = Input.GetAxis("Vertical");
            rotateObj.z = Input.GetAxis("Horizontal");
        }
        // Apply force to move the assets
        Player.AddForce(translateObj * speed * Time.deltaTime);
        // Apply force to rotate the assets
        Player.transform.Rotate(rotateObj * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            // Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        if (other.CompareTag("Goal"))
        {
            // Debug.Log($"You win!");
            winLoseText.color = Color.black;
            winLoseText.text = $"You Win!";
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
