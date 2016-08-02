using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ObjectCreater : MonoBehaviour {
	[Button("process1", "Create")] public int button1;
	public string readFilePath = "./Assets/OutputFiles/";
	public string readFileName = "outputFile.txt";

	private FileInfo fi;
	private string[] readedValues;
	/** 読み込みファイルの行数をカウント*/
	private int lowCount;
	private int objNum;
	private Queue<Vector3> objPosQueue = new Queue<Vector3>(){};
	private Vector4[] objectsRot;

	[SerializeField] public GameObject createdObj;

	public void process1(){
		this.Init ();
		this.ReadFile ();
		this.CreateObjects ();
	}

	private void Init(){
		lowCount = 0;
		objNum = 0;
	}

	/** read a file and save data into string[] readedValues*/
	private void ReadFile(){
		Debug.Log ( "Create button is clicked. " + "Try to read this file -> " + readFilePath + readFileName );
		fi = new FileInfo( readFilePath + readFileName );

		try {
			using (StreamReader sr = new StreamReader(fi.OpenRead())){
				while(sr.Peek() >= 0){
					string str = sr.ReadLine();
					readedValues = str.Split(',');
					if( lowCount++ > 0 ) this.saveVectorDataIntoQueue();
				}
			}
		} catch (IOException e){
			Debug.Log ("read file error!");
		}
	}

	/** 読み込んだデータをVector3形式でQueueに保存*/
	private void saveVectorDataIntoQueue(){
		float x, y, z;
		x = float.Parse(readedValues[0]);
		y = float.Parse(readedValues[1]);
		z = float.Parse(readedValues[2]);
		objPosQueue.Enqueue (new Vector3(x,y,z));
	}

	/** 保存したデータを基に、オブジェクトを子要素として生成*/
	private void CreateObjects(){
		while (objPosQueue.Count > 0) {
			GameObject go = (GameObject)Instantiate(createdObj, objPosQueue.Dequeue(), Quaternion.identity);
			go.transform.SetParent (this.transform, true);
		}
	}

	/** 一時確認用関数、本来の処理では使用しない*/
	private void temp(){
		
	}
}
