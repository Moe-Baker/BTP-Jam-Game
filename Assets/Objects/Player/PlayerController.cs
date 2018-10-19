using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game
{
	public class PlayerController : MonoBehaviour
	{
        Player player;
		public void Init(Player player)
        {
            this.player = player;
        }

        public void Process()
        {
            Look();
            Move();
        }

        [Header("Movement")]
        public float speed = 2.5f;
        public float acceleration = 10f;
        new public Rigidbody rigidbody { get { return player.rigidbody; } }
        void Move()
        {
            var input = new Vector2()
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = Input.GetAxisRaw("Vertical")
            };

            var velocity = rigidbody.velocity;
            velocity.y = 0f;

            var targetDirection = (transform.forward * input.y) + (transform.right * input.x);
            var targetVelocity = Vector3.ClampMagnitude(targetDirection * speed, speed);

            velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * Time.deltaTime);

            velocity.y = rigidbody.velocity.y;

            rigidbody.velocity = velocity;
        }

        [Header("Look")]
        public float sensitivity = 5f;
        public float range = 80f;
        public new Camera camera { get { return player.camera; } }
        void Look()
        {
            var input = new Vector2()
            {
                x = Input.GetAxis("Mouse X"),
                y = Input.GetAxis("Mouse Y")
            };

            player.transform.Rotate(Vector3.up, input.x * sensitivity);
            camera.transform.Rotate(Vector3.right, -input.y * sensitivity);
        }
	}
}