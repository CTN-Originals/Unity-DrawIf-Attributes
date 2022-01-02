using Exceptions;
using UnityEditor;
using UnityEngine;
using Utilities;

namespace com.ctn_originals.unity_drawif_attributes.Editor
{
	[CustomPropertyDrawer(typeof(DrawHeaderIfAttribute))]
	public class DrawHeaderIfPropertyDrawer : PropertyDrawer
	{
		DrawHeaderIfAttribute drawHeaderIf;
		SerializedProperty comparedField;

		private float propertyHeight;
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return propertyHeight;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			drawHeaderIf = attribute as DrawHeaderIfAttribute;
			comparedField = property.serializedObject.FindProperty(drawHeaderIf.ComparedField);

			// Get the value of the compared field.
			object comparedFieldValue = comparedField.GetValue<object>();

			// Is the condition met? Should the field be drawn?
			bool conditionMet = DrawIfExtension.DrawIfExtension.DrawIfConditionCheck(property, comparedField, comparedFieldValue, drawHeaderIf.ComparedValue, drawHeaderIf.ComparisonType);

			propertyHeight = base.GetPropertyHeight(property, label);

			if (conditionMet)
			{
				Rect headerRect = new Rect(position.x, position.y - (position.height * 0.4f), position.width, position.height + (position.height * 0.6f));
				Rect fieldRect = new Rect(position.x, position.y + (position.height / 1.65f), position.width, position.height / 2.5f);
				Rect totalRect = new Rect(headerRect.x + fieldRect.x, headerRect.y + fieldRect.y, headerRect.width + fieldRect.width, headerRect.height + fieldRect.height);
				propertyHeight *= 2.5f;

				//Draw The Header
				EditorGUI.LabelField(headerRect, new GUIContent(drawHeaderIf.Text), EditorStyles.boldLabel);
				//Draw the field that the attribute is attatched to, it just creates it again but with the header at the top
				EditorGUI.PropertyField(fieldRect, property, label);
			}
			else
			{
				//just draw the filed as default
				EditorGUI.PropertyField(position, property, label);
			}
		}
	}
}
