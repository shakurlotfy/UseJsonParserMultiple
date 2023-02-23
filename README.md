# UseJsonParserMultiple
Instruction of use json parser multiple

This is a simple way to parse your json result to datatable.
Please follow this steps to parse json to datatable
- Add JsonParserMultiple DLL to you project from Nuget.
- Use below sample code.
```
string JsonStr = "{\"id\":\"1\",\"name\":\"Jack\",\"age\":\"36\"}";
JsonParser.JParser JP = new JsonParser.JParser();
DataTable dt = JP.JsonConvert(JsonStr);
```
