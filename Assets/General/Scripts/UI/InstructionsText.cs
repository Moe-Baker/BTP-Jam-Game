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
	public class InstructionsText : MonoBehaviour
	{
        Game game;
        Text text;

		void Start()
        {
            game = FindObjectOfType<Game>();
            text = GetComponent<Text>();
        }

        void Update()
        {
            text.text = "Instructions:" +
"\n- Drink Coffee" +
"\n- Keep Your Team Awake." +
"\n- Finish Your Game In: " + Math.Round(game.timer.target - game.timer.current, 1) + "s." +
"\n- Approve Any Merge Requests." +
"\n- Upload Your Game When Finished.";
        }
	}
}