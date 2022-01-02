using UnityEngine;
using UnityEditor;
using Utilities;
using Exceptions;
using DrawIfExtension;

namespace com.ctn_originals.unity_drawif_attributes.Editor
{
    [CustomPropertyDrawer(typeof(DrawSpaceIfAttribute))]
    public class DrawSpaceIfPropertyDrawer : PropertyDrawer
    {
        DrawSpaceIfAttribute drawSpaceIf;
        SerializedProperty comparedField;

        private float propertyHeight;
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return propertyHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Set the global variables.
            drawSpaceIf = attribute as DrawSpaceIfAttribute;
            comparedField = property.serializedObject.FindProperty(drawSpaceIf.ComparedField);

            // Get the value of the compared field.
            object comparedFieldValue = comparedField.GetValue<object>();

            // Is the condition met? Should the field be drawn?
            bool conditionMet = DrawIfExtension.DrawIfExtension.DrawIfConditionCheck(property, comparedField, comparedFieldValue, drawSpaceIf.ComparedValue, drawSpaceIf.ComparisonType);

            propertyHeight = base.GetPropertyHeight(property, label);


            if (conditionMet)
            {
                Rect fieldRect = new Rect(position.x, position.y + (position.height / 2), position.width, position.height / 2);
                Rect spaceRect = new Rect(position.x, position.y, 0, position.height);
                Rect totalRect = new Rect(spaceRect.x + fieldRect.x, spaceRect.y + fieldRect.y, spaceRect.width + fieldRect.width, spaceRect.height + fieldRect.height);
                propertyHeight *= 2;

                //Draw the field that the attribute is attatched to, it just creates it again but with more space at the top
                EditorGUI.PropertyField(fieldRect, property, label);

                //Draw a label field without content to surve as a space
                EditorGUI.LabelField(spaceRect, GUIContent.none);
            }
            else
            {
                //just draw the filed as default
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}
