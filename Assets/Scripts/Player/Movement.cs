using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using Shared;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player{
    public class Movement : MonoBehaviour
    {

        public float moveSpeed = 2f;
        public float jumpForce = 2f;
        public GameObject groundCheck;

        public LayerMask groundLayer;

        
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private float _gravityScale = 10;
        private bool _jumped;
        private bool _crouching;

        private bool _canMove = true;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
            _crouching = false;
            _animator.SetBool(AnimatorTags.Crouch, false);
        }

        private void Update()
        {
            Jump();
            Crouch();

            if (transform.position.y <= -10)
            {
                Death();
            }
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;
            MovePlayer();
        }

        private void Jump()
        {
            if (GetIsGrounded() && !_jumped)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _jumped = true;
                    _animator.SetBool(AnimatorTags.Jump, true);
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
                    SoundManager.Instance.PlayJumpSound();
                }
            }
            else
            {
                _jumped = false;
                _animator.SetBool(AnimatorTags.Jump, false);
            }
        }

        private bool GetIsGrounded()
        {
            var collisions = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.1f, groundLayer);
            print(collisions.Length);
            return collisions.Length > 0;
        }

        private void MovePlayer()
        {
            var moveVector = Vector2.zero;
            if (Input.GetAxisRaw(Axes.Horizontal) > 0)
            {
                moveVector = new Vector2(Input.GetAxisRaw(Axes.Horizontal) * moveSpeed, _rigidbody.velocity.y);
                transform.localScale = new Vector3(1, transform.localScale.y);
            }
            else if(Input.GetAxisRaw(Axes.Horizontal) < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y);
                moveVector = new Vector2(Input.GetAxisRaw(Axes.Horizontal) * moveSpeed, _rigidbody.velocity.y);
            }
            else
            {
                moveVector = new Vector2(0, _rigidbody.velocity.y);
            }
            
            _animator.SetBool(AnimatorTags.Walk, Input.GetAxisRaw(Axes.Horizontal) != 0);
            _rigidbody.velocity = moveVector;
        }

        private void Crouch()
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _crouching = true;
                _animator.SetBool(AnimatorTags.Crouch, true);
                GetComponent<BoxCollider2D>().size = new Vector2(0.57f, 0.48f);
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                _crouching = false;
                _animator.SetBool(AnimatorTags.Crouch, false);
                GetComponent<BoxCollider2D>().size = new Vector2(0.57f, 0.66f);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Spike))
            {
                Death();
            }
        }

        private void Death()
        {
            SoundManager.Instance.PlayDeathSound();
            _canMove = false;
            GameManager.Instance.canChange = false;
            Invoke(nameof(Reload), 1f);
        }


        private void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
