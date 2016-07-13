using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Generator : MonoBehaviour {
	FileInfo fi;
	private string outputFileName = "outputFile.txt";
	private string readFileName = "inputFile.txt";
	private Vector3 pos;
	private Quaternion rot;
	string inputStr;
	private float samplingFrameNum = 100;

	// Use this for initialization
	void Start () {
		// get initial 3-dim ordinates
		pos = this.transform.position;

		// get path
		string txt = Application.dataPath;
		string txt2 = Application.persistentDataPath;
		Debug.Log(txt+","+txt2);

		// initial writer
		fi = new FileInfo(Application.dataPath + "/" + outputFileName);

		// write initial values
		this.WriteFile ("x,y,z");

		// test part, read input-file
		//this.ReadFile();
	}

	// Update is called once per frame
	void Update () {
		if ( --samplingFrameNum > 0) {
			pos = this.transform.position;
			rot = this.transform.rotation;
			this.WriteVecQuaToFile (pos, rot);
			samplingFrameNum = 100;
		}
	}

	/**labelを書き込み*/
	void WriteFile(string str){
		using (StreamWriter sw = fi.CreateText()){//上書き, Append-追加書き込み
			sw.WriteLine(str);
		}
	}

	/** position(x, y, z)を書き込み*/
	void WriteVectorToFile(Vector3 vec){
		using (StreamWriter sw = fi.AppendText()){//上書き, Append-追加書き込み
			sw.WriteLine(vec.x+","+vec.y+","+vec.z);
		}
	}

	/** position(x, y, z)+rotation(x, y, z)を書き込み*/
	void WriteVecQuaToFile(Vector3 vec, Quaternion qua){
		using (StreamWriter sw = fi.AppendText()){//上書き, Append-追加書き込み
			sw.WriteLine(vec.x+","+vec.y+","+vec.z+","+qua.x+","+qua.y+","+qua.z);
		}
	}

	/** not used now*/
	void ReadFile(){
		FileInfo fi = new FileInfo(Application.dataPath + "/" + outputFileName);
		try {
			using (StreamReader sr = new StreamReader(fi.OpenRead())){
				inputStr = sr.ReadToEnd();
			}
		} catch (Exception e){
			Debug.Log ("read file error!");
		}
		Debug.Log (inputStr);
	}

	void OnDestroy(){
		Debug.Log ("OnDestroy");
	}

}
