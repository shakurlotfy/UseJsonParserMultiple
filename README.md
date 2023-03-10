# UseJsonParserMultiple
**Convert Json to DataTable without any model or class**\
**Get the result immediately in a DataTable**\
~~Create models or classes for convert json in .NET~~

This is a simple way to parse your Json result to DataTable.\
Instruction of use Json parser multiple :

# Methode 1 :

Just follow these simple steps to use JsonParser 
- download JsonParserMultiple DLL from [Nuget](https://www.nuget.org/packages/JsonParserMultiple/)
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
JsonParser.JParser JP = new JsonParser.JParser();
DataTable dt = JP.JsonConvert(JsonStr);
```
> We have **age** in first and second jsonobjects, but in third one we have **zipcode** instead of **age**.\
Consequently in two first row we have **zipcode** with empty value and in third row we have empty value for **age** column and this value '5896472358' for **zipcode** column.\
Like below table :

|  id  |  name  |  age  |    zipcode   |
| --- | -------- | ----- | ------------- |
|  1  | Jack      | 36     |                    |
|  2  | Janatan| 30     |                    |
|  3  | Natasha|        | 5896472358 |

## Object In Object
Sometimes one of our value consists a JsonObject even a JsonArray. we can use JsonParser for value of that column specifically

### Example 1 :
```
string JsonStr = "{\"id\":\"1\",\"product\":\"TV\",\"number\":\"1\"
                  ,\"extrainfo\":{\"product_id\":\"157895004\",\"product_serial\":\"8874500\",\"product_model\":\"M23TU\"}}";

JsonParser.JParser JP = new JsonParser.JParser();
DataTable dt = JP.JsonConvert(JsonStr);
```
> In this JsonObject that concern to a sale order, **extrainfo** include of another JsonObject.\
If you need **extrainfo** values like ' product_id , product_serial , ... ' you must pass value of **extrainfo** column to JsonConvert.\
The result is like this below table in first step of convert.

|  id  |  product |  number |    extrainfo   |
| --- | ---------- | --------- | ------------- |
|  1  |      TV      |       1       | {"product_id":"157895004","product_serial":"8874500","product_model":"M23TU"} |

> In the next step I pass value of **extrainfo** column to JsonConvert and get values.\
Pass value like below code

```
DataTable dt_extrainfo = JP.JsonConvert(dt.Rows[0]["extrainfo"]);
```
|  product_id |  product_serial |  product_model |
| ------------ | ----------------- | ----------------- |
| 157895004 |       8874500      |       M23TU        | 

**Note:** You can use loop (for , while...) for convert another rows simply
```
DataTable dt_extrainfo;
for (int i = 0; i < dt.Rows.Count; i++)
{
    dt_extrainfo = new DataTable();
    dt_extrainfo = JP.JsonConvert(dt.Rows[i]["extrainfo"].ToString());
}
```
### Example 2 :
**Note:** Another solution for this case is **JsonConvertToDictionary** method.
> In previous example we had **extrainfo** column that must convert, we used again JsonConvert and get values in another DataTable\
now we can receive our information in a Dictionary. It is the DataTable that extrainfo column has a JasonObject\
and we want to get valus such as **product_serial**, pay attention to below code.

|  id  |  product |  number |    extrainfo   |
| --- | ---------- | --------- | ------------- |
|  1  |      TV      |       1       | {"product_id":"157895004","product_serial":"8874500","product_model":"M23TU"} |

```
Dictionary<string, string> DicExtrainfo = JP.JsonConvertToDictionary(dt.Rows[i]["extrainfo"].ToString());
```

# Convert to Dictionary
## You can get the result in a Dictionary instead of DataTable
**Note:** This method can uses just for one row not more\
&#9745; {"product_id":"157895004","product_serial":"8874500","product_model":"M23TU"}  (True)\
&#9746; [{"id":"1","product":"refrigerator"},{"id":"2","product":"carpet"}] (False) we have two rows in this case

### Example 1 :
```
string JsonStr = "{\"id\":\"1\",\"name\":\"Natasha\",\"zipcode\":\"5896472358\"}";
JsonParser.JParser JP = new JsonParser.JParser();
Dictionary<string, string> Dic = JP.JsonConvertToDictionary(JsonStr);
```
> **JsonConvertToDictionary** could use like **JsonConvert**.


## Object/Array In Object
### Example 1 :
In this JsonObject that concern to a sale order, **extrainfo** include of another JsonObject.\
If you need **extrainfo** values like ' product_id , product_serial , ... ' you must pass value of **extrainfo** key to JsonConvertToDictionary.

```
string JsonStr = "{\"id\":\"1\",\"product\":\"TV\",\"number\":\"1\"
                  ,\"extrainfo\":{\"product_id\":\"157895004\",\"product_serial\":\"8874500\"
                  ,\"product_model\":\"M23TU\"}}";

JsonParser.JParser JP = new JsonParser.JParser();
Dictionary<string, string> Dic = JP.JsonConvertToDictionary(JsonStr);
Dictionary<string, string> DicExtrainfo = JP.JsonConvertToDictionary(Dic["extrainfo"]);
```

# Methode 2 :

## Parse Json individually step by step by JsonObject and JsonArray classes.
### Example 1 :
```
string str = "{\"Table1\":[{\"id\":\"1\",\"name\":\"Koorosh\",\"age\":\"36\"},{\"id\":\"2\",\"name\":\"Ahoora\",\"age\":\"30\"}]
 ,\"Table2\":[{\"id\":\"1\",\"product\":\"Speacker\",\"price\":\"60\"},{\"id\":\"2\",\"product\":\"Monitor\",\"price\":\"250\"}]}";
JsonParser.JsonObject jsonobject = new JsonParser.JsonObject(str, "Table2");
string array_str = jsonobject.GetJsonArray();
JsonParser.JsonArray jarray = new JsonParser.JsonArray(array_str);
List<string> results = jarray.ConvertJsonArray();
for (int i = 0; i < results.Count; i++)
{
      Dictionary<string, string> jobj = jsonobject.GetJsonObject(results[i]);
      string id = jobj["id"];
      string product = jobj["product"];
      string price= jobj["price"];
}
```
> There is a JsonObject that includes two JsonArrays that challed 'Table1' and 'Table2'\
We want to parse 'Table2', so use above code\
1 ) First and second line : get JsonArray that called 'Table2'\
2 ) Third and fourth line : get JsonObjects in JsonArray\
3 ) Then by use a simple loop we can access to our values

**Note:** Don't forget each of the values can includes another JasonObject or a JsonArray.
