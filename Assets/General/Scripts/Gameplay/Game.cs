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

        void Start()
        {
            player = FindObjectOfType<Player>();

            Begin();
        }

        public void Begin()
        {
            timer.Begin();

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

        void Win()
        {
            Debug.Log("Game Won");
        }

        void Lose()
        {
            Debug.Log("Game Lost");
        }
    }
}