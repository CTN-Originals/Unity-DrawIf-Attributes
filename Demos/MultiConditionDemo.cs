using System.Collections.Generic;
using UnityEngine;

public class MultiConditionDemo : MonoBehaviour {
	[Header("List")]
	public bool x;
	public bool y;
	public bool z;

	[DrawIf("x", true)] public float xF = 0.23f;
	//[DrawIf("x", "y", true, ComparisonType.Equals)] public Vector2 xyV2 = new Vector2(0.842f, 2.45f);
	[DrawIf("z", true)] public Vector3 xyzV3 = new Vector3(3.47f, 93.33f, 5.245f);

	[Header("Array")]
	public bool x2;
	public bool y2;

	[DrawIf("x2,y2", true, false)] public Vector2 xyV2Array = new Vector2(0.842f, 2.45f);

	//public List<string> str = new List<string>("awd", "dghj");
}
