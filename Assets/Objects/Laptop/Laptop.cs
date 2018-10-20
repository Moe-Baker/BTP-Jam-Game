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
	public class Laptop : MonoBehaviour
	{
        public CameraTransition transition;

        void Start()
        {
            GetComponent<Interactable>().OnInteraction += OnInteract;
        }

        void OnInteract()
        {
            FindObjectOfType<Player>().control = false;

            transition.Do();
            Player.SetCursor(true);
        }

        public void Exit()
        {
            StartCoroutine(ExitProcedure());
        }
        IEnumerator ExitProcedure()
        {
            var player = FindObjectOfType<Player>();

            player.CameraTransition.Do();
            Player.SetCursor(false);

            while (player.CameraTransition.IsRunning)
                yield return new WaitForEndOfFrame();

            player.control = true;
        }
    }
}