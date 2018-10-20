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

        public Button mergeButton;

        public Button uploadButton;

        Game game;

        void Start()
        {
            game = FindObjectOfType<Game>();

            GetComponent<Interactable>().OnInteraction += OnInteract;

            mergeButton.onClick.AddListener(game.RemoveMergeRequest);
            uploadButton.onClick.AddListener(game.Upload);
        }

        void Update()
        {
            mergeButton.gameObject.SetActive(game.MergeRequest);
            uploadButton.gameObject.SetActive(game.ProgressRate == 1f);
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