# String.Search
[![NuGet version (String.Search)](https://img.shields.io/nuget/v/String.Search.svg?style=flat-square)](https://www.nuget.org/packages/String.Search/)

## What is String.Search?
String.Search is a simple library to implement a full text search with given patterns.

## How do I get started?
Install the package from Nuget
```
Install-Package String.Search
```


## Examples
For given text, such as
```csharp
    private const string EnglishText = @"It’s a technique for building a computer program that learns from data. 
It is based very loosely on how we think the human brain works. 
First, a collection of software “neurons” are created and connected together, 
allowing them to send messages to each other. Next, the network is asked to solve a problem, 
which it attempts to do over and over, each time strengthening the connections that lead to success and diminishing those that lead to failure. 
For a more detailed introduction to neural networks, Michael Nielsen’s Neural Networks and Deep Learning is a good place to start. For a more technical overview, 
try Deep Learning by Ian Goodfellow, Yoshua Bengio, and Aaron Courville.";
```

- Search
```csharp
    var results = EnglishText.Search(new List<string>
    {
        "Deep Learning",       // There are two matches in text, case insensitive
        "brain",               // One match in text
        "neural networks"      // Two matches in text
    }).ToArray();

    Assert.AreEqual(5, results.Length);
    Assert.AreEqual((497, "neural networks"), results[1]); // 497 is the position
    Assert.AreEqual(1, results.Where(x => x.value == "Neural Networks").Count());
    Assert.AreEqual(2, results.Where(x => x.value == "Deep Learning").Count());
```

- Replace
```csharp
    var result = EnglishText.Replace(new List<string>
    {
        "Deep Learning",
        "brain",
        "neural networks"
    });

    Assert.AreEqual(@"It’s a technique for building a computer program that learns from data. 
It is based very loosely on how we think the human ***** works. 
First, a collection of software “neurons” are created and connected together, 
allowing them to send messages to each other. Next, the network is asked to solve a problem, 
which it attempts to do over and over, each time strengthening the connections that lead to success and diminishing those that lead to failure. 
For a more detailed introduction to ***************, Michael Nielsen’s *************** and ************* is a good place to start. For a more technical overview, 
try ************* by Ian Goodfellow, Yoshua Bengio, and Aaron Courville.", 
    result);
```

- DistanceTo
```csharp
    var result = "toy".DistanceTo("boy"); // result == 1
    result = "Template".DistanceTo("tepmlate"); // result == 2
    result = "人工智能".DistanceTo("人工智障"); // result == 1
```

It also works for Unicode strings.
