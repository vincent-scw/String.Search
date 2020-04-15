# String.Search

## What is String.Search?
String.Search is a simple library to implement a fuzzy search in a given list.

## How do I get started?
Install the package from Nuget
```
Install-Package String.Search
```


Define your candidates
```
  private List<string> candidates = new List<string>
  {
      "FT 20' STANDARD CONTAINER",
      "FT 40' STANDARD CONTAINER",
      "HC 40' HIGH CUBE CONTAINER",
      "GP 45' GENERAL PURPOSE CONTAINER",
      "HC 45' HIGH CUBE CONTAINER",
      "DR 20' DRY REEFER CONTAINER",
      "FC 20' FLEXIBAG CONTAINER",
      "FG 20' FOOD GRADE CONTAINER",
      "FR 20' FLAT RACK CONTAINER",
      "GH 20' GARMENT ON HANGER CONTAINER",
  };
```

Search
```
  var result = new StringSearch(_candidates).Search("40' High Cube Dry");
  Assert.AreEqual(("_40 HC 40' HIGH CUBE CONTAINER", 3), result);
```

You can also define weights for words and score threshold.
```
  var weights = new ScoreWeights();
  weights.Add(
      ("container", 0.1m),
      ("STANDARD", 0.3m)
  );
  
  var result = new StringSearch(_candidates, weights).Search("25' STANDARD CONTAINER");
  Assert.AreEqual((null, 0.4m), result);
```
