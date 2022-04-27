using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 50f;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    private Rigidbody _rigidbody;
    private int count;
    private Rigidbody rb;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    [SerializeField] private float _movementForce = 10f;
    [SerializeField] private double _maximumVelocity = 10f;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();

        count = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
                winTextObject.SetActive(false);
    }
    void FixedUpdate ()
    {
        if (_rigidbody.velocity.magnitude >= _maximumVelocity)
            return;
        if (Input.GetKey(KeyCode.W))
        _rigidbody.AddForce(_movementForce * transform.forward);
        if (Input.GetKey(KeyCode.S))
        _rigidbody.AddForce(_movementForce * transform.forward);
        if (Input.GetKey(KeyCode.D))
        _rigidbody.AddForce(_movementForce * transform.forward);
        if (Input.GetKey(KeyCode.A))
        _rigidbody.AddForce(_movementForce * transform.forward);

        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();
        

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
        }
		
        if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
        }
    }
    void SetCountText()
	{
		countText.text = "Score: " + count.ToString();

		if (count >= 176) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
    }
}
