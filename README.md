# Ollix API

## Como rodar?

- **Banco de dados:**

    - Abra o arquivo ollix-backend.sln no Visual Studio 2022.

    - Vá em 'Tools' > 'Nuget Package Manager' > 'Package Manager Console'

    - Selecione o seguinte Default Project: "Ollix.Infrastructure.Data"

    - Caso seja a primeira vez que esteja rodando o projeto, rode o seguinte comando para geração do script de Banco de Dados completo:

        - ```Script-Migration```
    - Após isso sera gerado um script de Banco de Dados, que você poderá executar localmente.
 
- **Configurações da Aplicação**
  
     O projeto possui algumas chaves de configuração (Secrets) que precisams ser ajustadas para serem rodadas localmente:
  
  - Vá até o projeto Ollix.API
  - Adicione um arquivo chamado "appsettings.Development.json"
  - Nesse arquivo cole o seguinte json:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "{SuaStringDeConexaoLocal Ex: Server=localhost;Database={databaseName};User Id={userDbName};Password={userDbPassword}}"
  },
  "JwtSettings": {
    "Key": "quMjRLeWqR3Jp7jHWAaTlck1f1wOTavr",
    "Audience": "https://hom-ollix-api.azurewebsites.net",
    "Issuer": "https://hom-ollix-api.azurewebsites.net"
  },
  "EnviromentSettings": {
    "Enviroment": "Develop",
    "ApiName":  "Ollix API (Develop) v1"
  }
}
```
  - Feito isso, substitua o {SuaStringDeConexaoLocal} pela sua String de conexão local. (Certifique-se de que o Script de Banco de Dados foi executado nessa mesma conexão)
      
