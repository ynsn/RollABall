﻿using System;
using UnityEngine;

namespace TeamNameHere
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SphereCollider))]
    public class BallController : MonoBehaviour
    {
        [SerializeField] private bool isJumpingAllowed = true;

        [SerializeField] private float speed = 10.0f;
        [SerializeField] private float gravity = 10.0f;
        [SerializeField] private float maxVelocityChange = 10.0f;
        [SerializeField] private float jumpHeight = 2.0f;

        [SerializeField] private Camera camera;

        private bool mayJump = true;
        private bool isGrounded;
        private Rigidbody playerRigidBody;

        private void Awake()
        {
            playerRigidBody = GetComponent<Rigidbody>();

            playerRigidBody.freezeRotation = true;
            playerRigidBody.useGravity = false;
        }

        private Vector3 CalculateVelocityChange(Vector3 velocityChange, float maxVelChange)
        {
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelChange, maxVelChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelChange, maxVelChange);
            velocityChange.y = 0;

            return velocityChange;
        }

        private void FixedUpdate()
        {
            Vector3 lookAt = camera.transform.forward;
            lookAt.y = 0;

            playerRigidBody.rotation = Quaternion.LookRotation(lookAt, Vector3.up);

            if (isGrounded)
            {
                Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                targetVelocity = transform.TransformDirection(targetVelocity);
                targetVelocity *= speed;

                Vector3 velocity = playerRigidBody.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);

                velocityChange = CalculateVelocityChange(velocityChange, maxVelocityChange);

                playerRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);

                if (isJumpingAllowed && mayJump && Input.GetButton("Jump"))
                {
                    playerRigidBody.velocity = new Vector3(velocity.x, CalculateJumpSpeed(), velocity.z);
                }
            }

            playerRigidBody.AddForce(new Vector3(0, -gravity * playerRigidBody.mass, 0));

            isGrounded = false;
        }

        private void OnCollisionStay()
        {
            isGrounded = true;
        }

        private float CalculateJumpSpeed()
        {
            return Mathf.Sqrt(2 * jumpHeight * gravity);
        }

        private void OnDrawGizmos()
        {
            Debug.DrawLine(camera.transform.position, camera.transform.position + camera.transform.forward,
                Color.magenta);
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.forward,
                Color.red);
        }
    }
}