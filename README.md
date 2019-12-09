# Twitch Sample Overlay
Sample for learning for how Twitch (and other streams) overlay works.

## Projects

 * Twitch - web app to send requests to Twitch API
 * TwitchShared - some classes that shared with projects
 * Microsoft.AspNetCore.WebHooks.Receivers - port of [AspNetCore.WebHooks preview](https://github.com/aspnet/AspLabs/tree/master/src/WebHooks) to AspNetCore 3.1
 * TwitchLib.Webhooks - fork of [TwitchLib.Webhook](https://github.com/TwitchLib/TwitchLib.Webhook) to work with ported version of AspNetCore.WebHooks
 * TwitchOverlays - web app with overlays and webhook

## Overview
 Most of overlays for streams is just web apps that adds to programms such as OBS Studio throw BrowerSource.
There is one sample overlay with new follower notification.