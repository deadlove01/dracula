using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class TXTReader : Singleton<TXTReader> {



	// Use this for initialization
	void Start () {
		LevelData.Instance.data_Level = new List<Level> ();
		InitLevel ();
	}

	public void InitLevel()
	{
		TextAsset data = Resources.Load(GameConst.UrlConfigLevel_1) as TextAsset;
		string[] text = data.text.Split (new string[] {"\r\n"}, System.StringSplitOptions.RemoveEmptyEntries);
		for (int i = 1; i < text.Length; i++) 
		{
			Level level = new Level();
			level.id = int.Parse(text[i].Split(',')[0]);
			level.name = text[i].Split(',')[1];
			level.type = text[i].Split(',')[2];
			level.posX = int.Parse(text[i].Split(',')[3]);
			level.posY = int.Parse(text[i].Split(',')[4]);
			LevelData.Instance.data_Level.Add(level);
		}

		for (int i = 0; i < LevelData.Instance.data_Level.Count; i++) 
		{
			Debug.Log(LevelData.Instance.data_Level[i].id + ", " + LevelData.Instance.data_Level[i].name);
		}
	}
}

public enum TypeLevel
{
	Map,
	NPC,
	House,
	Character,
}

public class Level
{
	public int id;
	public string name;
	public string type;
	public int posX;
	public int posY;
}
