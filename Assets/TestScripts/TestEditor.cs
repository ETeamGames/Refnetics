using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(PutPathManager))]               //!< 拡張するときのお決まりとして書いてね
public class CharacterEditor : Editor           //!< Editorを継承するよ！
{
    bool folding = false;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // target は処理コードのインスタンスだよ！ 処理コードの型でキャストして使ってね！
        //PutPathManager tar = target as PutPathManager;

        /* -- カスタム表示 -- */

        // -- 体力 --
        //EditorGUILayout.LabelField("体力(現在/最大)");
        //tar.PathName = EditorGUILayout.TextField(tar.PathName);
        /*EditorGUILayout.BeginHorizontal();
        chara.m_hp_now = EditorGUILayout.IntField(chara.m_hp_now, GUILayout.Width(48));
        chara.m_hp_max = EditorGUILayout.IntField(chara.m_hp_max, GUILayout.Width(48));
        EditorGUILayout.EndHorizontal();*/

        // -- 速度 --
        // chara.m_spd = EditorGUILayout.FloatField("速度", chara.m_spd);

        // -- 名前 --
        //chara.m_name = EditorGUILayout.TextField("名前", chara.m_name);

        // -- 道中オブジェクト --
        /*List<PUTPATHINFO> list = tar.objects;
        int i, len = list.Count;

        // 折りたたみ表示
        if (folding = EditorGUILayout.Foldout(folding, "道中オブジェクト"))
        {
            // リスト表示
            for (i = 0; i < len; ++i)
            {
                list[i].obj = EditorGUILayout.ObjectField(list[i].obj, typeof(GameObject), true) as GameObject;
                list[i].position = EditorGUILayout.FloatField(list[i].position);
            }

            GameObject go = EditorGUILayout.ObjectField("追加", null, typeof(GameObject), true) as GameObject;
            if (go != null) {
                PUTPATHINFO pinfo = new PUTPATHINFO();
                pinfo.obj = go;
                pinfo.position = 0;
                list.Add(pinfo);
            }
        }*/
    }
}
