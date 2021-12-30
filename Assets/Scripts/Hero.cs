using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hero : MonoBehaviour
{
    Rigidbody2D rigidbody;
    BoxCollider2D boxCollider;
    [SerializeField] float speed = 10f, jumpVelocity = 10f;
    [SerializeField] GameObject normalSprite, sneakingSprite, jumpingSprite;
    [SerializeField] AudioSource jumpSound;
    public bool isJumping = false, isSneaking = false;


void Awake(){
    IsDead = false;
}    public static bool IsDead = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
       rigidbody.velocity= transform.right * speed ;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground")
        {
            IsDead = true;
            Destroy(rigidbody);
            Destroy(this);
        }
    }
    float epsilon = 0.000001f;
    float prevVelocity = 0;
    bool PlayerInstructsToSneak(){
        return Input.GetAxis("Vertical")<0 ;
    }
    bool PlayerInstructsToJump(){
        return Input.GetAxis("Vertical")>0f|| Input.GetKey(KeyCode.Space);
    }
    void SneakOn()
    {
        isSneaking = true;
        boxCollider.offset = new Vector2(0, -0.25f);
        boxCollider.size = new Vector2(1, 0.5f);

        normalSprite.SetActive(false);
        sneakingSprite.SetActive(true);
    }
    void SneakOff()
    {
        isSneaking = false;
        boxCollider.offset = new Vector2(0, 0);
        boxCollider.size = new Vector2(1, 1);

        sneakingSprite.SetActive(false);
        normalSprite.SetActive(true);
    }
    void JumpOn()
    {
        isJumping = true;
        rigidbody.velocity = new Vector2(speed, jumpVelocity);

        jumpSound.Play();

        normalSprite.SetActive(false);
        jumpingSprite.SetActive(true);
    }
    void JumpOff()
    {

        isJumping = false;


        jumpingSprite.SetActive(false);
        normalSprite.SetActive(true);
    }
    void Update()
    {
        if (isJumping && prevVelocity <= epsilon && rigidbody.velocity.y <= epsilon && rigidbody.velocity.y >= -epsilon)
        {
            JumpOff();
        }
        if (isSneaking && !PlayerInstructsToSneak())
        {
            SneakOff();
        }
        prevVelocity = rigidbody.velocity.y;
        if (!isJumping && !isSneaking)
        {
            if (PlayerInstructsToJump())
            {
                JumpOn();
            }
            else if (PlayerInstructsToSneak())
            {
                SneakOn();
            }
        }
        rigidbody.velocity= new Vector2(speed,rigidbody.velocity.y);
    }
}
