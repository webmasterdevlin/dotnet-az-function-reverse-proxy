## Reverse Proxy for jsonplaceholder.typicode.com

### Requirements

- proxies.json with routes

```json
{
  "$schema": "http://json.schemastore.org/proxies",
  "proxies": {
    "resource": {
      "matchCondition": {
        "methods": ["GET", "POST"],
        "route": "{resource}"
      },
      "backendUri": "https://jsonplaceholder.typicode.com/{resource}",
      "responseOverrides": {
        "response.headers.Content-Type": "application/json",
        "response.headers.x-api-key": "%SECRET%"
      }
    }
  }
}
```

- csproj update

```xml
    <None Update="proxies.json">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
```

### With

- fake api key setup by editing local.settings.json

- edit local.settings.json

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "SECRET": "my_secret"
  }
}
```
