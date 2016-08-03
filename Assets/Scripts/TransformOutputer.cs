﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

/*
 * アタッチした対象のPosition, Rotation座標を一定フレーム毎(必要でれば手動で)にサンプリング(ファイル出力)するクラス
 * */
public class TransformOutputer : MonoBehaviour {
	private FileInfo fi;
	private string outputFilePath = "OutputFiles/";
	private string outputFileName = "outputFile.txt";
	private string readFileName = "inputFile.txt";
	private Vector3 pos;
	private Quaternion rot;
	private string inputStr;
	/** サンプリングレート(default FPS * minites) */
	public int samplingFrameRate = 60*5;
	private int samplingFrameNum;

	// Use this for initialization
	void Start () {
		// get initial 3-dim ordinates
		pos = this.transform.position;

		// initial writer
		fi = new FileInfo(Application.dataPath + "/" + outputFilePath + outputFileName);

		// write initial label-values
		this.WriteFile ("pos.x, pos.y, pos.z, rot.x , rot.y, rot.z, rot.w");

		// other initialization
		Init();
	}

	// Update is called once per frame
	void Update () {
		// samplingFrameRate毎にデータを保存
		if ( --samplingFrameNum <= 0) this.ConductSampling (false);
	}

	/** use for some initialization*/
	void Init () {
		samplingFrameNum = samplingFrameRate;
	}

	/// <summary>データを保存し,ファイルに書き込み.</summary>
	/// <param name="manual"> True=手動呼び出し,Init()は呼ばれない. False=自動呼び出し,Init()も呼び出す.</param>
	public void ConductSampling(bool manual){
		pos = this.transform.position;
		rot = this.transform.rotation;
		this.WriteVecQuaToFile (pos, rot);
		if (!manual) this.Init (); 
		Debug.Log ("Transform data are sampled...");
	}

	/**labelを書き込み*/
	private void WriteFile(string str){
		using (StreamWriter sw = fi.CreateText()){//上書き, Append-追加書き込み, Create-新規書き込み
			sw.WriteLine(str);
		}
	}

	/** position(x, y, z)を書き込み*/
	private void WriteVectorToFile(Vector3 vec){
		using (StreamWriter sw = fi.CreateText()){//上書き, Append-追加書き込み, Create-新規書き込み
			sw.WriteLine(vec.x+","+vec.y+","+vec.z);
		}
	}

	/** position(x, y, z)+rotation(x, y, z, w)を書き込み*/
	private void WriteVecQuaToFile(Vector3 vec, Quaternion qua){
		using (StreamWriter sw = fi.AppendText()){//上書き, Append-追加書き込み
			sw.WriteLine(vec.x+","+vec.y+","+vec.z+","+qua.x+","+qua.y+","+qua.z+","+qua.w);
		}
	}

}
