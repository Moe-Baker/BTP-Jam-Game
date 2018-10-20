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
	public class CameraTransition : MonoBehaviour
	{
        public Transform target;

        public float speed = 5f;

        public bool autoPlay = false;

        void Start()
        {
            if (autoPlay)
                Do();
        }

        public void Do()
        {
            coroutine = StartCoroutine(Procedure());
        }

        Coroutine coroutine;
        public bool IsRunning { get { return coroutine != null; } }
        IEnumerator Procedure()
        {
            var camera = Camera.main;

            var startPosition = camera.transform.position;
            var startRotation = camera.transform.rotation;

            var time = 0f;

            while (true)
            {
                time = Mathf.MoveTowards(time, 1f, speed * Time.deltaTime);

                camera.transform.position = Vector3.Lerp(startPosition, target.position, time);
                camera.transform.rotation = Quaternion.Lerp(startRotation, target.rotation, time);

                if (Mathf.Approximately(time, 1f))
                    break;

                yield return new WaitForEndOfFrame();
            }

            coroutine = null;
        }
	}
}