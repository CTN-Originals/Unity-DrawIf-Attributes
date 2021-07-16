using UnityEditor;
using UnityEngine;
using Utilities;
using Exceptions;
using DrawIfExtension;

[CustomPropertyDrawer(typeof(DrawIfAttribute))]
public class DrawIfPropertyDrawer : PropertyDrawer
{
    // Reference to the attribute on the property.
    DrawIfAttribute drawIf;

    // Field that is being compared.
    SerializedProperty comparedField;

    // Height of the property.
    private float propertyHeight;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return propertyHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Set the global variables.
        drawIf = attribute as DrawIfAttribute;

		bool conditionMet = false;
		//if (!drawIf.multible) {
		//}
		//else {
			
		//}
		// Get the compared field
		comparedField = property.serializedObject.FindProperty(drawIf.ComparedPropertyName);
		// Get the value of the compared field.
		object comparedFieldValue = comparedField.GetValue<object>();
		// Is the condition met? Should the field be drawn?
		conditionMet = DrawIfExtension.DrawIfExtension.DrawIfConditionCheck(property, comparedField, comparedFieldValue, drawIf.ComparedValue, drawIf.ComparisonType);
        

        // The height of the property should be defaulted to the default height.
        propertyHeight = base.GetPropertyHeight(property, label);
        
        // If the condition is met, simply draw the field. Else...
        if (conditionMet)
        {
            EditorGUI.PropertyField(position, property, label);
        }
        else
        {
            //...check if the disabling type is read only. If it is, draw it disabled, else, set the height to zero.
            if (drawIf.DisablingType == DisablingType.ReadOnly)
            {
                GUI.enabled = false;
                EditorGUI.PropertyField(position, property, label);
                GUI.enabled = true;
            }
            else
            {
                propertyHeight = 0f;
            }
        }
    }
}