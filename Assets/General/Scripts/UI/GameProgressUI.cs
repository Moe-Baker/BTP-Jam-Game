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
	public class GameProgressUI : MonoBehaviour
	{
        public Slider slider;
        public Text label;

        Game game;

        void Start()
        {
            game = FindObjectOfType<Game>();
        }

        void Update()
        {
            slider.value = game.Progress;
            label.text = "Game Progress: " + ((int)(game.Progress * 100)).ToString() + "%";
        }
    }
}