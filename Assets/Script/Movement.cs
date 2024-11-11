using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
      // Start is called before the first frame update
    [SerializeField] private CharacterController characterController;
    private float horizontal,vertical;
    [SerializeField] private float speed = 3f;//hướng di chuyển
    private Vector3 movement;// tọa độ của player
    [SerializeField]
    Animator animator;
    private bool isAttack;
    public enum CharacterState
    {
        Normal, Attack
    }
    //trạng thái hiện tại của player
    public CharacterState currentState;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//Chạy theo từng Frame
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (!isAttack)
        {
            isAttack = Input.GetMouseButtonDown(0);
        }
    }
    void FixedUpdate() // Chạy theo tần xuất thường dùng để chạy vật lý
    {
        switch (currentState)
        {
            case CharacterState.Normal:
                Calculater();
                ;break;
            case CharacterState.Attack:;break;
        }
        characterController.Move(movement);
    }
    void Calculater()
    {
        if (isAttack)
        {
            ChangeState(CharacterState.Attack);
            animator.SetFloat("Run",0);
            return;
        }
        movement.Set(horizontal, 0, vertical);
        movement.Normalize(); // Chuẩn hóa Vector
        movement = Quaternion.Euler(0, -45, 0) * movement;
        movement *= speed * Time.deltaTime;

        animator.SetFloat("Run", movement.magnitude);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            //xoay theo góc di chuyển của nhân vật
           

        }
    }
    //Hàm thay đổi trạng thái hiện tại của player
    public void ChangeState(CharacterState newState)
    {
        //clear cache giúp clear hết các state
        isAttack = false; //trạng thái mặc định của attack
        //Thoát khỏi state hiện tại
        switch (currentState)
        {
            case CharacterState.Normal: ;break;
            case CharacterState.Attack:;break;
        }
        //Chuyển qua state mới
        switch (newState)
        {
            case CharacterState.Normal:;break;
            case CharacterState.Attack:
                animator.SetTrigger("Attack");
                ;break;
        }
        currentState = newState;
    }
    private void OnDisable()
    {
        horizontal = 0;
        vertical = 0;
        isAttack = false;
    }
    public void EndAttack()
    {
        ChangeState(CharacterState.Normal);
    }
}