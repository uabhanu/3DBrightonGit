using UnityEngine;
#if UNITY_5_5_OR_NEWER
using UnityEngine.SceneManagement;
#endif

public class PlayerScript : MonoBehaviour 
{
    Animator anim;
	AudioSource audioSource;
    bool running;
    float ellapsedTime;
	Rigidbody rigidBody;

	[SerializeField] float strafeSpeed = 2f;
    [SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundTest;
	
	void Start() 
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();

		ellapsedTime = 0f;
	}
	
	void Update() 
	{
		if(!running)
		{
			if(Input.anyKeyDown)
			{
				anim.SetTrigger ("Start");

				//This functionality is added later
				if(GameManager.instance != null)
                {
                    GameManager.instance.StartScoring();
                }

				running = true;
			}
			return;
		}

		ellapsedTime += Time.deltaTime;
		anim.speed = 1f + ellapsedTime / 100f;
		
		#if UNITY_EDITOR || UNITY_STANDALONE
		
		if(Input.GetButtonDown("TurnLeft"))
        {
            TurnLeft();
        }
			
		else if(Input.GetButtonDown ("TurnRight"))
        {
            TurnRight();
        }
			
		else if(Input.GetButtonDown("Slide"))
        {
            Slide();
        }

		else if(Input.GetButtonDown("Jump"))
        {
            Jump ();
        }
			
		
		transform.Translate(Input.GetAxis("Mouse X") * strafeSpeed * Time.deltaTime , 0f , 0f);
		
		#elif UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8
		
		transform.Translate(Input.acceleration.x * 2f * strafeSpeed * Time.deltaTime , 0f , 0f);
		
		#endif
	}
	
	void FixedUpdate()
	{
		if(!Physics.CheckSphere(groundTest.position , 0.35f , whatIsGround))
		{
			anim.SetBool("Grounded", false);
			rigidBody.isKinematic = false;
			
			if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
			
			Invoke("Restart" , 4f);

			//This functionality is added later
			if(GameManager.instance != null)
            {
                GameManager.instance.StopScoring();
            }
		}
	}
	
	public void TurnLeft()
	{
		transform.Rotate(0f , -90f , 0f);
	}
	
	public void TurnRight()
	{
		transform.Rotate(0f , 90f , 0f);
	}
	
	public void Slide()
	{
		anim.SetTrigger("Slide");
	}
	
	public void Jump()
	{
		anim.SetTrigger("Jump");
	}
	
	void Restart()
	{
		#if UNITY_5_5_OR_NEWER
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		#else
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}
}
