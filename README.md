# JsonLogic.Net - JsonLogic implementation in .Net platform

This implementation is strongly based on the project [yavuztor/JsonLogic.Net](https://github.com/yavuztor/JsonLogic.Net). Since we wanted to follow the respective naming conventions of the languages we use and still share rules between frontend and backend, this implementation was extended by a conversion of variable names in the rules or `data` objects.

JsonLogic.Net is an implementation of [JsonLogic](http://jsonlogic.com/) in .Net platform. Implementation includes [all supported operators documented on JsonLogic site](http://jsonlogic.com/operations.html).

## Dependencies

JsonLogic.Net has a hard dependency on [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/). It is a common library for json handling and very easy to use.

## Usage

```csharp
// The data that the rule will run against. 
object data = new {MyNumber = 8};

// Rule definition retrieved as JSON text
string jsonText="{\">\": [{\"var\": \"MyNumber\"}, 3]}";

// Parse json into hierarchical structure
var rule = JObject.Parse(jsonText);

// Create an evaluator with default operators.
var evaluator = new JsonLogicEvaluator(EvaluateOperators.Default());

// Apply the rule to the data.
object result = evaluator.Apply(rule, data);
```

The evaluator does not maintain any state and is thread-safe. Depending on your use case, you can add the evaluator as a singleton in your dependency injection container. You can also have multiple evaluators with different custom operations.

## Conversion of Naming Conventions

|Source Naming Convention|Target Naming Convention|
|------------------------|------------------------|
|camelCase               |PascalCase              |
|PascalCase              |camelCase               |

```csharp
// The data that the rule will run against. 
object data = new {MyNumber = 8};

// Rule definition retrieved as JSON text
string jsonText="{\">\": [{\"var\": \"myNumber\"}, 3]}";

// Parse json into hierarchical structure
var rule = JObject.Parse(jsonText);

// Create an evaluator with default operators, provide naming convention of rules object (camelCase) and data object (PascalCase).
var evaluator = new JsonLogicEvaluator(EvaluateOperators.Default(NamingConventionEnum.CamelCase, NamingConventionEnum.PascalCase));

// Apply the rule to the data.
object result = evaluator.Apply(rule, data);
```