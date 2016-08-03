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
	private Queue<Quaternion> objRotQueue = new Queue<Quaternion>(){};
	/** 生成されるオブジェクト*/
	[SerializeField] public GameObject createdObj;

	public void process1(){
		this.DeleteChildObjects ();
		this.Init ();
		this.ReadFile ();
		this.CreateObjects ();
	}

	/// <summary>Deletes the all child objects of this.</summary>
	void DeleteChildObjects(){
		for( int i = this.transform.childCount - 1 ; i >= 0 ; --i ){
			GameObject.DestroyImmediate( this.transform.GetChild( i ).gameObject );
		}
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
				while( sr.Peek() >= 0 ){
					string str = sr.ReadLine();
					readedValues = str.Split(',');
					// labelは例外処理
					if( lowCount++ > 0 ) this.saveDataIntoQueue();
				}
			}
		} catch (IOException e){
			Debug.Log ("read file error!");
		}
	}

	/** 読み込んだデータをVector3,Quaternion型でQueueに保存*/
	private void saveDataIntoQueue(){
		float x, y, z, w;
		// Transform.position
		x = float.Parse(readedValues[0]);
		y = float.Parse(readedValues[1]);
		z = float.Parse(readedValues[2]);
		objPosQueue.Enqueue (new Vector3(x,y,z));
		// Transform.rotation
		x = float.Parse(readedValues[3]);
		y = float.Parse(readedValues[4]);
		z = float.Parse(readedValues[5]);
		w = float.Parse(readedValues[6]);
		objRotQueue.Enqueue (new Quaternion(x,y,z,w));
	}

	/** 保存したデータを基に、オブジェクトを子要素として生成*/
	private void CreateObjects(){
		while (objPosQueue.Count > 0) {
			GameObject go = (GameObject)Instantiate(createdObj, objPosQueue.Dequeue(), objRotQueue.Dequeue());
			go.transform.SetParent (this.transform, true);
		}
	}

	/** 一時確認用関数、本来の処理では使用しない*/
	private void temp(){
		
	}
}
