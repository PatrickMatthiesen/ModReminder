$APIKey = Read-Host -Prompt 'Input your API Key'

dotnet user-secrets set "Bungie:ApiKey" "$APIKey" --project ./Server/