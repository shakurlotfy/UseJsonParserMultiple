# UseJsonParserMultiple
**Convert Json to DataTable without any model or class**\
**Get the result immediately in a DataTable**\
~~Create models or classes for convert json in .NET~~

This is a simple way to parse your Json result to DataTable.\
Instruction of use Json parser multiple :

Just follow these simple steps to use JsonParser 
- download JsonParserMultiple DLL from Nuget
- Use below samples code.

Just run this sample code to parse json to datatable after download the DLL :
```
string JsonStr = "{\"id\":\"1\",\"name\":\"Jack\",\"age\":\"36\"}";
JsonParser.JParser JP = new JsonParser.JParser();
DataTable dt = JP.JsonConvert(JsonStr);
```

|  id  |  name  |  age  |
| --- | -------- | ----- |
|  1  | Jack      | 36     |

## JsonArray
### Example 1 :
```
string JsonStr = "[{\"id\":\"1\",\"name\":\"Jack\",\"age\":\"36\"}
                  ,{\"id\":\"2\",\"name\":\"Janatan\",\"age\":\"30\"}
                  ,{\"id\":\"3\",\"name\":\"Natasha\",\"age\":\"32\"}]";
JsonParser.JParser JP = new JsonParser.JParser();
DataTable dt = JP.JsonConvert(JsonStr);
```

|  id  |  name  |  age  |
| --- | -------- | ----- |
|  1  | Jack      | 36     |
|  2  | Janatan| 30     |
|  3  | Natasha| 32     |

### Example 2 :
**It may that our JsonArray have different values in their jsonobjects.**\
For example :
```
string JsonStr = "[{\"id\":\"1\",\"name\":\"Jack\",\"age\":\"36\"}
                  ,{\"id\":\"2\",\"name\":\"Janatan\",\"age\":\"30\"}
                  ,{\"id\":\"3\",\"name\":\"Natasha\",\"zipcode\":\"5896472358\"}]";
```
> We have **age** in first and second jsonobjects, but in third one we have **zipcode** instead of **age**.\
Consequently in two first row we have **zipcode** with empty value and in third row we have empty value for **age** column and this value '5896472358' for **zipcode** column.\
Like below table :

|  id  |  name  |  age  |    zipcode   |
| --- | -------- | ----- | ------------- |
|  1  | Jack      | 36     |                    |
|  2  | Janatan| 30     |                    |
|  3  | Natasha|        | 5896472358 |
