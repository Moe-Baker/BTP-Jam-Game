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
	public class AI : MonoBehaviour
	{
        public float contribution;

        public float burstTime = 2f;

        public AIState state = AIState.Idle;

        public int sleepChance = 10;

        public Interactable interactable;

        public ParticleSystem sleepParticles;

        void Awake()
        {
            FindObjectOfType<Game>().OnStateChange += OnGameStateChange;

            interactable.OnInteraction += OnInteraction;
        }

        void OnGameStateChange(GameState gameState)
        {
            if (gameState == GameState.Playing)
                StartCoroutine(Procedure());
            else if (gameState == GameState.Ended)
            {
                StopAllCoroutines();
                state = AIState.Idle;
            }
        }

        float timer = 0f;
        IEnumerator Procedure()
        {
            state = AIState.Working;

            while(true)
            {
                if (state == AIState.Working)
                    timer = Mathf.MoveTowards(timer, burstTime, Time.deltaTime);

                if(Mathf.Approximately(timer, burstTime))
                {
                    FindObjectOfType<Game>().Progress += contribution;
                    timer = 0f;
                }

                if (Random.Range(0, sleepChance) == 0)
                    state = AIState.Sleeping;

                interactable.active = state == AIState.Sleeping;
                sleepParticles.enableEmission = state == AIState.Sleeping;

                if (!interactable.active)
                    sleepParticles.Clear();

                yield return new WaitForEndOfFrame();
            }
        }

        void OnInteraction()
        {
            if(state == AIState.Sleeping)
            {
                state = AIState.Working;
            }
        }
    }

    public enum AIState
    {
        Idle, Working, Sleeping
    }
}