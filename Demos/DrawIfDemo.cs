using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawIfDemo : MonoBehaviour
{
	public bool showInputs;
	[DrawIf("showInputs", true)] public string input  = "something...";
	[DrawIf("showInputs", true)] public string input2 = "something else...";
	[DrawIf("showInputs", true)] public string input3 = "something else else...";

	[DrawSpaceIf("showInputs", true)]

	[Range(0, 10)] public int number;
	[DrawIf("number", 8, ComparisonType.GreaterOrEqual)] public Vector3 vector = new Vector3(0.25f, 24.435f, 8.4f);

	[DrawHeaderIf("Read-Only?", "showInputs", true)]
	public bool readOnly;
	[DrawIf("readOnly", false, ComparisonType.Equals, DisablingType.ReadOnly)] public int int1 = 20;
	[DrawIf("readOnly", false, ComparisonType.Equals, DisablingType.ReadOnly)] public int int2 = 345;
	[DrawIf("readOnly", false, ComparisonType.Equals, DisablingType.ReadOnly)] public string string1 = "string 1";
	[DrawIf("readOnly", false, ComparisonType.Equals, DisablingType.ReadOnly)] public string string2 = "string 2";


	#region OverwriteExamples
	private void Test(string str) { }
	private void Test(string str, string str2, string str3) { }
	private void Test(string str, string str2, int int1) { }
	private void TestIt() {
		//Test("",);
	}

	public void MyFunc(int a) {
		// do thing with int a
	}

	public void MyFunc(int a, int b) {
		// do thing with a and b
	}

	public void MyFunc(int a, string myString) {
		// do whatever
	}
	#endregion
}
