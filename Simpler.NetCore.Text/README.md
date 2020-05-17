# Simpler.NetCore.Text

## Extension methods

### `IfBlank`

A fluent alternative to `String.IsNullOrWhiteSpace`.

**Usage:**

```cs
"Text".IsBlank();          // false
"  ".IsBlank();            // true
((String) null).IsBlank(); // true
``` 

 

### `NonBlank`

Use on a string variable to return it only if it's not blank (isn't `null` and contains more than just white-space).
Basically a fluent shortcut/alternative to `String.IsNullOrWhiteSpace(str) ? str : null`.

**Usage:**

```cs
String t = "Text";
String b = "    ";
String n = null;

t.NonBlank();            // "Text"
b.NonBlank() ?? "Blank"; // "Blank"
b.NonBlank();            // null
n.NonBlank("Was null");  // "Was null" 
``` 

 
 ### `Part`
 
 Return a part of a `String`. 
 A more versatile version of `String.Substring` that supports negative arguments (offsets from the end of the string) and
 doesn't throw an exception if the resulting string is shorter than offset.
 
 ```cs
"OffsetSub".Part(0, -3);     // "Offset"
"123SubRegular".Part(3, 3);  // "Sub"
"NotEverything".Part(3);     // "Everything"
"UnMoored".Part(2, 99);      // "Moored"
"Empty".Part(10, -99);       // ""
"LastOne".Part(-3);          // "One"
"TrickOrTreat".Part(-7, -5); // "Or" 
```


### `Text`

Return a non-null version of a given `String`.
Syntactic shorthand for `text ?? ""`.

```cs
String? value = "something";
value.Text();            // "something"
value = null;
value.Text();            // ""
```


### `TrimSuffix`

Remove a substring from the end of a `String`.

```cs
"markdown.md".TrimSuffix(".md"); // "markdown"
```