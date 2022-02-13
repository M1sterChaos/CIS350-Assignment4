/*
 * (Austin Buck)
 * (Assignment 4)
 * (Moves obstacles past the player going to the left)
 */
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;

    private PlayerController pc;

    private float leftBound = -15f;

    private void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(pc.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
