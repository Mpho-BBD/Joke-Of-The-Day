# Joke Backend

Some information about the backend 

# Building/Running

## Dev Mode

### Permissions

Our backedend use secrets stored in AWS Secrets Manger.
Make sure you have the permissions setup correctly

The easiest way to do this is to create a user in IAM with the following permissions and then make it your default profile.

```json
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Sid": "JokeSecretsAccess",
            "Effect": "Allow",
            "Action": [
                "secretsmanager:GetSecretValue",
                "secretsmanager:DescribeSecret"
            ],
            "Resource": [
                "arn:aws:secretsmanager:us-east-1:387198229710:secret:DBSecret-IDENTIFIERHERE",
                "arn:aws:secretsmanager:us-east-1:387198229710:secret:AppSecret-IDENTIFIERHERE"
            ]
        },
        {
            "Sid": "ListSecrets",
            "Effect": "Allow",
            "Action": "secretsmanager:ListSecrets",
            "Resource": "*"
        }
    ]
}
```
Then use this in your 

> ~/.aws/credentials
```txt
[default]
aws_access_key_id=XXXXXXXXXXXXXXXX
aws_secret_access_key=00000000000000000000000000000000000000
```

### DB

Currently, our application does not have a way to change the live db to a db used for dev so you need to change the line refenrncing the secret value to the dev database line to the one indicated

> JokeOfTheDay/Data/JokeContxt.cs
```c#
...
Models.DbSecretModel secretModel = this.secretManagerService.getDatabaseCredential(secretID);
        return $"Server='{YOUR-DEV-SERVER-HERE}'; " +
                $"Port={secretModel.Port}; " +
...
```

### Redirect

Same issue with the redirect url. Change it to `http://localhost:4200/session`

> JokeOfTheDay/Middleware/TokenCache.cs
```c#
...
    request.AddParameter("client_id", secrets.client_id);
    request.AddParameter("redirect_uri", "http://localhost:4200/session");
    request.AddParameter("scope", "openid");
...
```
----

You can then run the application with this cli command 

```sh
dotnet run --project JokeOfTheDay
```

** Note:
The dev will redirect you to the cognito just fine but the redirect url will send you back to `localhost:4200/session?code=XXXXXXXXX` we don't expect anything to be running on the endpoint. It is just a convenient place for us to grab the Authentication Code from to test with in Swagger. **

You can then see the log output for the 

```sh
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7184
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5184
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: 
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

## Prod Mode

```sh
dotnet run --project JokeOfTheDay  --launch-profile JokeOfTheDay-Production
```
