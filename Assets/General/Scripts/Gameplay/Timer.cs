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
	public class Timer : MonoBehaviour
	{
        public float current = 0f;
        public float target = 200f;

        public float CompletionRate { get { return current / target;} }
        public bool IsComplete { get { return current == target; } }

        Coroutine coroutine;
        public bool IsRunning { get { return coroutine != null; } }

        public event Action OnBegin;
        public event Action OnComplete;

        void Start()
        {
            Begin();
        }

        public void Begin()
        {
            coroutine = StartCoroutine(Procedure());
        }

        IEnumerator Procedure()
        {
            current = 0f;

            if (OnBegin != null) OnBegin();

            while (current != target)
            {
                current = Mathf.MoveTowards(current, target, Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            if (OnComplete != null) OnComplete();
        }

        public void Stop()
        {

        }
	}
}