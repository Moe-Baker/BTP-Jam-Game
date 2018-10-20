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
	public class Game : MonoBehaviour
	{
        [Range(0f, MaxProgress)]
        public float _progress = 0f;
        public float Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = Mathf.Clamp(value, 0f, MaxProgress);
            }
        }
        public event Action<float> OnProgressChange;

        public const float MaxProgress = 100f;

        public float ProgressRate { get { return Progress / MaxProgress; } }

        public Timer timer;

        Player player;

        GameState state = GameState.Idle;
        public GameState State { get { return state; } }
        public event Action<GameState> OnStateChange;
        void ChangeState(GameState newState)
        {
            state = newState;

            player.control = state == GameState.Playing;

            if (OnStateChange != null) OnStateChange(state);
        }

        void Start()
        {
            player = FindObjectOfType<Player>();
            player.control = false;

            Player.SetCursor(true);
        }

        public void Begin()
        {
            ChangeState(GameState.Playing);

            timer.Begin();
            player.CameraTransition.Do();
            Player.SetCursor(false);

            StartCoroutine(Procedure());
        }

        protected virtual IEnumerator Procedure()
        {
            while(true)
            {
                if (Progress == MaxProgress)
                {
                    Win();
                    break;
                }

                if (timer.IsComplete)
                {
                    Lose();
                    break;
                }

                if (Mathf.Approximately(player.Energy.Rate, 0f))
                {
                    Lose();
                    break;
                }

                yield return new WaitForEndOfFrame();
            }
        }

        public GameObject winMenu;
        void Win()
        {
            ChangeState(GameState.Ended);

            Player.SetCursor(true);

            winMenu.SetActive(true);
        }

        public GameObject loseMenu;
        void Lose()
        {
            ChangeState(GameState.Ended);
            Player.SetCursor(true);

            loseMenu.SetActive(true);
        }
    }

    public enum GameState
    {
        Idle, Playing, Ended
    }
}