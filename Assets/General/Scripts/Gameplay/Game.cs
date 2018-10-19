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
        [Range(0f, 1f)]
        public float _progress = 0f;
        public float Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = Mathf.Clamp01(value);
            }
        }
    }
}