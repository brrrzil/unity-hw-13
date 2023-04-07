using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hw10.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerInput : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2.0f;
        private Rigidbody playerRigidBody;
        private Vector3 movement;

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2;
        }
#endif

        private void Awake()
        {
            playerRigidBody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(horizontal, 0, vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerRigidBody.AddForce(movement * speed);
        }
    }
}