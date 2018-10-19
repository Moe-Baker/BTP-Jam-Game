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
	public class PlayerInteract : MonoBehaviour
	{
        public LayerMask mask = Physics.DefaultRaycastLayers;

        public float range = 1.5f;
        
        public Interactable Target { get; private set; }

        RaycastHit raycastHit;

        Player player;
        public void Init(Player player)
        {
            this.player = player;
        }

        new public Camera camera { get { return player.camera; } }

        public void Process()
        {
            Detect();

            if (Target != null && Input.GetButtonDown("Interact"))
                Target.Interact();
        }

        void Detect()
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, range, mask))
            {
                Target = raycastHit.transform.GetComponent<Interactable>();
            }
            else
            {
                Target = null;
            }
        }
	}
}