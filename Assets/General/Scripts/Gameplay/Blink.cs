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
	public class Blink : MonoBehaviour
	{
        public float speed = 1f;

        public float range = 1f;

        public Image[] eyelids;

        public AnimationCurve curve;

        void Update()
        {
            SetValue(curve.Evaluate(Time.time * speed) * range);
        }

        void SetValue(float value)
        {
            foreach (var eyelid in eyelids)
                SetValue(value, eyelid);
        }

        void SetValue(float value, Image target)
        {
            target.fillAmount = value;

            var color = target.color;

            color.a = value;

            target.color = color;
        }
	}
}