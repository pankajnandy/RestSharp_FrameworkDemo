# Framework_RestSharp
RestSharp Framework with SpecFlow

I have created Tests using
1> MSTest
2> SpecFlow

The Framework is based on Trasfer object Pattern, Where DTO/Models are created to encapsulate data to send as Request and receive as response.

I have shown Two ways to call the REST API Calls. We can use either way. 
For the Tests in Specflow , it uses the RestHelper.cs to excute the REST Calls.
For the Test in MsTest , it uses the CreateOperations.cs to execute the REST Calls .
