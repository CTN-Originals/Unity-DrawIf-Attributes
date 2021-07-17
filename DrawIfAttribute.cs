using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Draws the field/property ONLY if the copared property compared by the comparison type with the value of comparedValue returns true.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DrawIfAttribute : PropertyAttribute
{
	public List<string> propertyNameList;
	public List<object> comparedValueList;


	public string ComparedPropertyName { get; private set; }
    public List<string> ComparedPropertyNameList { get; private set; }
    public string[] ComparedPropertyNameArray { get; private set; }
    public object ComparedValue { get; private set; }
    public object[] ComparedValueArray { get; private set; }
    public ComparisonType ComparisonType { get; private set; }
    public DisablingType DisablingType { get; private set; }

	public bool multible;
	public bool isList;


    /// <summary>
    /// Only draws the Field/Attribute if a/the condition(s) is met.
    /// </summary>
    /// <param name="comparedPropertyName">The name of the property that is being compared (case sensitive).</param>
    /// <param name="comparedValue">The value the property is being compared to.</param>
    /// <param name="comparisonType">The type of comparison the values will be compared by.</param>
    /// <param name="disablingType">The type of disabling that should happen if the condition is NOT met.</param>
    public DrawIfAttribute(string comparedPropertyName, object comparedValue, ComparisonType comparisonType = ComparisonType.Equals, DisablingType disablingType = DisablingType.DontDraw)
    {
        ComparedPropertyName = comparedPropertyName;
        ComparedValue = comparedValue;
        ComparisonType = comparisonType;
        DisablingType = disablingType;
		multible = false;
    }
	public DrawIfAttribute(string comparedPropertyName1, string comparedPropertyName2, object comparedValue, ComparisonType comparisonType = ComparisonType.Equals, DisablingType disablingType = DisablingType.DontDraw, bool multi = true) {

		//string rawPropertyNames = comparedPropertyNames.Replace(" && ", ",");
		//string[] propertyNames = rawPropertyNames.Split(',');

		List<string> comparedPropertyNameList = new List<string>();
		comparedPropertyNameList.Add(comparedPropertyName1);
		comparedPropertyNameList.Add(comparedPropertyName2);
		//foreach (string name in propertyNames) {
		//	comparedPropertyNameList.Add(name);
		//}

		ComparedPropertyNameList = comparedPropertyNameList;
		ComparedValue = comparedValue;
		ComparisonType = comparisonType;
		DisablingType = disablingType;
		multible = true;
		isList = true;
	}
	public DrawIfAttribute(string comparedPropertyName, object comparedValue, bool isList, ComparisonType comparisonType = ComparisonType.Equals, DisablingType disablingType = DisablingType.DontDraw, bool multi = true) {

		string[] comparedPropertyNameArray = comparedPropertyName.Split(',');

		ComparedPropertyNameArray = comparedPropertyNameArray;
		ComparedValue = comparedValue;
		ComparisonType = comparisonType;
		DisablingType = disablingType;
		multible = true;
		isList = false;
	}
}