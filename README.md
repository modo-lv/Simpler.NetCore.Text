# Simpler.NetCore.Text

## Extension methods

### `.IsBlank()`

A fluent alternative to `String.IsNullOrWhiteSpace`.

```cs
"Text".IsBlank();          // false
"  ".IsBlank();            // true
((String) null).IsBlank(); // true
```

### `.NotBlank()`

The reverse of `IsBlank`; a fluent, more readable shorthand for `!String.IsNullOrWhiteSpace(value);`.

```cs
"Text".NotBlank();           // true
"    ".NotBlank();           // false
"".NotBlank;                 // false
(null as String).NotBlank(); // false
```


### `.NonBlank()`

Use on a string variable to return it only if it's not blank (isn't `null` and contains more than just white-space).
Basically a fluent shortcut/alternative to `String.IsNullOrWhiteSpace(str) ? str : null`.

```cs
String t = "Text";
String b = "    ";
String n = null;

t.NonBlank();            // "Text"
b.NonBlank() ?? "Blank"; // "Blank"
b.NonBlank();            // null
n.NonBlank("Was null");  // "Was null" 
```


### `.Part(from, to)`

Return a part of a `String`. 
A more versatile version of `String.Substring` that supports negative arguments (offsets from the end of the string) and doesn't throw an exception if the resulting string is shorter than the requested length.

```cs
"OffsetSub".Part(0, -3);     // "Offset"
"123SubRegular".Part(3, 3);  // "Sub"
"NotEverything".Part(3);     // "Everything"
"UnMoored".Part(2, 99);      // "Moored"
"Empty".Part(10, -99);       // ""
"LastOne".Part(-3);          // "One"
"TrickOrTreat".Part(-7, -5); // "Or" 
```

### `.Repeat(times)`

Repeat text a given number of times.

```cs
"9".Repeat(4); // "9999"
```


### `.Text()`

Return a non-null version of a given `String`.
Syntactic shorthand for `text ?? ""`.

```cs
String? value = "something";
value.Text();            // "something"
value = null;
value.Text();            // ""
```


### `.TrimSuffix(suffix)`

Remove a substring from the end of a `String`.

```cs
"markdown.md".TrimSuffix(".md"); // "markdown"
```

### `.TrimPrefix(prefix)`

Remove a substring from the start of a `String`.

```cs
"user@email".TrimPrefix("user"); // "@email"
```