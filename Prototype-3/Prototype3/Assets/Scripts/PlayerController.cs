/*
 * (Austin Buck)
 * (Assignment 4)
 * (Controls all player movements)
 */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;
    private Animator pa;
    public ParticleSystem pse;
    public ParticleSystem psd;

    public AudioClip js;
    public AudioClip ds;

    private AudioSource pas;

    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        pas = GetComponent<AudioSource>();
        pa = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        pa.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;

        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            pa.SetTrigger("Jump_trig");
            psd.Stop();
            pas.PlayOneShot(js);
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            psd.Play();
            isOnGround = true;
        }
        if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            pas.PlayOneShot(ds);
            pse.Play();
            pa.SetBool("Death_b", true);
            pa.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
