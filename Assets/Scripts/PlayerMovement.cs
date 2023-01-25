using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;
    public float moveSpeed = 5f;
    private Vector2 movement;
    public Vector2 savedPosition;
    private GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        savedPosition = rigidBody.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameIsPaused)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("GamePaused", false);
        }
        else
        {
            animator.SetBool("GamePaused", true);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void Save()
    {
        savedPosition = rigidBody.position;
    }
    public void Load()
    {
        rigidBody.position = savedPosition;
    }
}
