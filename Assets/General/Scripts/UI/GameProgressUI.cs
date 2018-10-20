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

            slider.minValue = 0f;
            slider.maxValue = Game.MaxProgress;
        }

        public Color uploadColor = Color.green;
        public Color mergeColor = Color.red;
        void Update()
        {
            slider.value = game.Progress;

            if(game.ProgressRate == 1f)
            {
                label.color = uploadColor;
                label.text = "Developement Complete, Upload The Game From Your PC";
            }
            else if(game.MergeRequest)
            {
                label.color = mergeColor;
                label.text = "Merge Request Recieved, Please Approve From Your PC";
            }
            else
            {
                label.color = Color.grey;
                label.text = "Game Progress: " + ((int)game.Progress).ToString() + "%";
            }
        }
    }
}