using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class DrawSpaceIfAttribute : PropertyAttribute {
	public string ComparedField { get; private set; }
	public object ComparedValue { get; private set; }
	public ComparisonType ComparisonType { get; private set; }

	/// <summary>
	/// Only draws the Field/Attribute if a/the condition(s) is met.
	/// </summary>
	/// <param name="comparedField">The name of the property that is being compared (case sensitive).</param>
	/// <param name="comparedValue">The value the property is being compared to.</param>
	/// <param name="comparisonType">The type of comparison the values will be compared by.</param>
	public DrawSpaceIfAttribute(string comparedField, object comparedValue, ComparisonType comparisonType = ComparisonType.Equals) {
		ComparedField = comparedField;
		ComparedValue = comparedValue;
		ComparisonType = comparisonType;
	}
}
