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
	public class Player : MonoBehaviour
	{
        public bool control = true;

        new public Rigidbody rigidbody { get; private set; }
        new public CapsuleCollider collider { get; private set; }

        new public Camera camera { get; private set; }
        public CameraTransition CameraTransition { get; private set; }

        public PlayerEnergy Energy { get; protected set; }
        public PlayerController Controller { get; protected set; }
        public PlayerInteract Interact { get; protected set; }

        void Awake()
        {
            rigidbody = GetComponentInChildren<Rigidbody>();
            collider = GetComponentInChildren<CapsuleCollider>();

            camera = GetComponentInChildren<Camera>();
            CameraTransition = GetComponentInChildren<CameraTransition>();

            Energy = GetComponentInChildren<PlayerEnergy>();
            Energy.Init(this);

            Controller = GetComponentInChildren<PlayerController>();
            Controller.Init(this);

            Interact = GetComponentInChildren<PlayerInteract>();
            Interact.Init(this);
        }

        void Update()
        {
            Controller.Process();

            Interact.Process();

            Energy.Process();
        }
	}
}