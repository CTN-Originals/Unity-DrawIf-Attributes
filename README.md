# Unity-DrawIf-Attributes
Credits to: [**Or-Aviram**](https://forum.unity.com/members/or-aviram.1019764/) <br>
Some of these files are created by Or-Aviram. Click [here](https://forum.unity.com/threads/draw-a-field-only-if-a-condition-is-met.448855/) to see the original post.

## Draw If | Preview
https://user-images.githubusercontent.com/52889675/125857120-e0a61ad7-8106-4ca0-98f8-75dc451631b1.mp4

**DrawIf Preview | Code**
```cs
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
}
```

## Draw Header If | Preview
https://user-images.githubusercontent.com/52889675/125855939-fd4983cb-51c6-42db-846e-21ea0c6a69e7.mp4

**DrawHeaderIf Preview | Code**
```cs
public class HeaderDemo : MonoBehaviour
{
	public bool someBool;
	[DrawHeaderIf("Input Header", "someBool", true)]
	public string input  = "something...";
	public string input2 = "something else...";
	public string input3 = "something else else...";

	[DrawHeaderIf("Number Header", "someBool", true)]
	[Range(0, 10)] [Tooltip(">= 8 | Draws Header")] public int number;

	[DrawHeaderIf("Vector Header", "number", 8, ComparisonType.GreaterOrEqual)]
	public Vector3 vector = new Vector3(0.25f, 24.435f, 8.4f);
	public Transform someTransform;
}
```
