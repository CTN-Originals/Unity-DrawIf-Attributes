using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ctn_originals.unity_drawif_attributes;

public class SpaceDemo : MonoBehaviour
{
	public bool someBool;
	[DrawSpaceIf("someBool", true)]
	public string input  = "something...";
	public string input2 = "something else...";
	public string input3 = "something else else...";
	[DrawSpaceIf("someBool", true)]
	[Range(0, 10)] [Tooltip(">= 8 | Draws Space")] public int number;
	[DrawSpaceIf("number", 8, ComparisonType.GreaterOrEqual)]
	public Vector3 vector = new Vector3(0.25f, 24.435f, 8.4f);
	public Transform someTransform;
}
