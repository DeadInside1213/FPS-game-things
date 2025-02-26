using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] private AudioClip atkSound;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip deadSound;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    private float gravity = -9.81f;
    
    public float jumpHeight = 1f;
    
    public int maxHP, curHP;
    
    public AttackZone atkZone;
    
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        
    }
    // Receive the in put from InputManager.cs and apply to character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        //audioSource.PlayOneShot(runSound);
        //animator.SetFloat("Run", controller.velocity.magnitude);
        playerVelocity.y += gravity * 1.5f * Time.deltaTime;
        if (controller.isGrounded && playerVelocity.y < 0) playerVelocity.y = -2f;   
        controller.Move(playerVelocity * Time.deltaTime);
       
        //Debug.Log(playerVelocity.y);
        
    }
    

    public void Jump()
    {
        if (isGrounded)
        {
            audioSource.PlayOneShot(atkSound);
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f  * gravity);
        }
    }

    public void ProcessAttack()
    {
        animator.SetTrigger("Attack");
        audioSource.PlayOneShot(atkSound);
    }


    public void BeginDamage()
    {
        atkZone.beginDamage();
    }

    public void EndDamage()
    {
        atkZone.endDamage();
    }
    
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        curHP = Mathf.Max(0, curHP);
        if (curHP <= 0)
        {
            animator.SetTrigger("Dead");
            audioSource.PlayOneShot(deadSound);
            Destroy(gameObject, 2f); 
        }
    }
}
