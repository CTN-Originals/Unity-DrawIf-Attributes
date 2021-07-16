using Exceptions;
using System;
using UnityEditor;
using UnityEngine;
using Utilities;

namespace DrawIfExtension {

	public static class DrawIfExtension {
		//public static class DrawIfAttributeInfo {
		//	public static SerializedProperty comparedField;
		//	public static object coparedValue;
		//}

		public static bool DrawIfConditionCheck(SerializedProperty property, SerializedProperty conparedField, object comparedFieldValue, object comparedValue, ComparisonType comparisonType) {
			bool conditionMet = false;

			// References to the values as numeric types.
			NumericType numericComparedFieldValue = null;
			NumericType numericComparedValue = null;
			try {
				// Try to set the numeric types.
				numericComparedFieldValue = new NumericType(comparedFieldValue);
				numericComparedValue = new NumericType(comparedValue);
			}
			catch (NumericTypeExpectedException) {
				// This place will only be reached if the type is not a numeric one. If the comparison type is not valid for the compared field type, log an error.
				if (comparisonType != ComparisonType.Equals && comparisonType != ComparisonType.NotEqual) {
					Debug.LogError("The only comparsion types available to type '" + comparedFieldValue.GetType() + "' are Equals and NotEqual. (On object '" + property.serializedObject.targetObject.name + "')");
					return conditionMet;
				}
			}

			// Is the condition met? Should the field be drawn?

			// Compare the values to see if the condition is met.
			switch (comparisonType) {
				case ComparisonType.Equals:
					if (comparedFieldValue.Equals(comparedValue))
						conditionMet = true;
					break;

				case ComparisonType.NotEqual:
					if (!comparedFieldValue.Equals(comparedValue))
						conditionMet = true;
					break;

				case ComparisonType.GreaterThan:
					if (numericComparedFieldValue > numericComparedValue)
						conditionMet = true;
					break;

				case ComparisonType.SmallerThan:
					if (numericComparedFieldValue < numericComparedValue)
						conditionMet = true;
					break;

				case ComparisonType.SmallerOrEqual:
					if (numericComparedFieldValue <= numericComparedValue)
						conditionMet = true;
					break;

				case ComparisonType.GreaterOrEqual:
					if (numericComparedFieldValue >= numericComparedValue)
						conditionMet = true;
					break;
			}

			return conditionMet;
		}
	}
}