using System.Collections;
using System.Collections.Generic;
using IronPython.Hosting;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PythonExample : MonoBehaviour
{
	[SerializeField]
	private Text greeting, randomNumber;

	// Use this for initialization
	void Start ()
	{
		var engine = Python.CreateEngine ();

		ICollection<string> searchPaths = engine.GetSearchPaths ();
		
		//Path to the folder of test.py
		searchPaths.Add (Application.dataPath);
		//Path to the Python standard library
		searchPaths.Add (Application.dataPath + @"/StreamingAssets"  + @"/Lib/");
		engine.SetSearchPaths (searchPaths);

		dynamic py = engine.ExecuteFile (Application.dataPath + @"/StreamingAssets" + @"/Python/test.py");
		/*dynamic test = py.Test ("Codemaker");
		greeting.text = "Greeting: " + test.display ();
		randomNumber.text = "Random Number: " + test.random_number (1, 5);*/
	}

}
