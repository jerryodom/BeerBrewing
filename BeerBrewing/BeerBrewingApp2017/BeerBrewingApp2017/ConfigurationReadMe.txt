To prevent some sensitive information from getting in to source control I've added some configuration.  
You may need to add 2 config files.   ConnectionStrings.config and PrivateAppSettings.config and add the settings there as described here:

http://johnatten.com/2014/04/06/asp-net-mvc-keep-private-settings-out-of-source-control/

<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=.;Initial Catalog=????;Integrated Security=???" providerName="System.Data.SqlClient" />
</connectionStrings>


<appSettings>
  <add key="webpages:Version" value="3.0.0.0" />
  <add key="webpages:Enabled" value="false" />
  <add key="ClientValidationEnabled" value="true" />
  <add key="UnobtrusiveJavaScriptEnabled" value="true" />
  <add key="SMSAccountIdentification" value="???" />
  <add key="SMSAccountPassword" value="???" />
  <add key="SMSAccountFrom" value="+???" />
  <add key="FBAppId" value="???"/>
  <add key="FBAppSecret" value="???"/>
</appSettings>

Note:  The SMS information/values were for a Trilio implmentation.   