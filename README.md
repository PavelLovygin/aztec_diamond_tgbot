# Aztec Diomod Telegram Bot

## About

This example demonstrates simple Telegram Bot, which generate Aztec Diamond

## Configuration

You should provide your Telegram Bot token with one of the available providers.
Read futher on [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0).
We provide plaecehoder for bot configuration in `appsettings*.json`. You have to replace {BOT_TOKEN} with actual Bot token:

```json
"BotConfiguration": {
  "BotToken": "{BOT_TOKEN}"
}
```

Watch [Configuration in .NET 6](https://www.youtube.com/watch?v=6Fg54CEBVno&t=170s) talk for deep dive into .NET Configuration.

## Run
Launch the bot and send a telegram request, where ```n``` is the rank:

```
/generate_aztec_diamond {n}
```