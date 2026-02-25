# SignalR – Day 1 Study Notes

---

## What is SignalR?

SignalR is a library that lets the **server push data to clients in real-time** without the client asking for it.  
Think of it like a chat app — when someone sends a message, everyone sees it instantly.

---

## How Does the Connection Work?

SignalR automatically picks the **best technology** available for the connection:

| Technology | Notes |
|---|---|
| **WebSockets** | Best option, not supported everywhere |
| **Server-Sent Events** | Good fallback |
| **Forever Frame** | IE only |
| **Long Polling** | Works everywhere, but slowest |

> ?? **Tip:** You can force a specific transport or set a priority order:
> ```js
> con.start({ transport: ['webSockets', 'serverSentEvents', 'longPolling'] });
> ```
> After the connection starts, check which one was chosen:
> ```js
> $.connection.hub.transport.name
> ```

---

## Server Side

### 1. Startup (OWIN)

SignalR needs to be registered when the app starts. This is done in the `Startup` class:

```csharp
public void Configuration(IAppBuilder app)
{
    app.MapSignalR();
}
```

> ?? **Tip:** You can change the default SignalR URL by passing a path:
> `app.MapSignalR("/signalr");`

---

### 2. The Hub Class

A **Hub** is the server-side class that clients connect to and call methods on.

```csharp
[HubName("chat")]           // name clients use to connect
public class ChatHub : Hub
{
    [HubMethodName("sendMessage")]  // name clients use to call this method
    public void SendMessage(string name, string message)
    {
        Clients.All.newMessage(name, message);  // call method on ALL connected clients
    }
}
```

**Key points:**
- `[HubName]` ? sets the name clients use to reach this hub. Without it, the class name is used.
- `[HubMethodName]` ? sets the name clients use to call this method. Without it, the method name is used.
- `Clients.All` ? sends to **every connected client**.
- `Clients.All.newMessage(...)` ? calls the `newMessage` function defined on the **client side**.

---

### Bonus – Sending an Object Instead of Parameters

Instead of separate parameters, you can send a whole object:

```csharp
[HubMethodName("sendMessage")]
public void SendMessage(Message message)
{
    Clients.All.newMessage(message.Name, message.Text);
}
```

And on the client side you would call it like:
```js
prox.invoke("sendMessage", { Name: name, Text: $("#txt").val() });
```

---

## Client Side

There are **two ways** to connect from the client. The recommended way for custom control is **Method 2**.

---

### Method 1 – Default Proxy (Auto-generated)

SignalR can auto-generate a proxy file for you at `/signalr/hubs`.

```html
<script src="/signalr/hubs"></script>
```

```js
proxy = $.connection.chat;       // connect to hub named "chat"
$.connection.hub.start();        // start the connection

proxy.client.newMessage = function (n, m) {   // subscribe to server calls
    $("ul").append("<li>" + n + ": " + m + "</li>");
};

function send() {
    proxy.server.sendMessage(name, $("#txt").val());  // call server method
}
```

> ?? **Note:** `proxy.client` = methods the server will call **on you**.  
> `proxy.server` = methods **you call on the server**.

---

### Method 2 – Custom Proxy (Manual)

You define everything yourself — no auto-generated file needed.

```js
// Step 1 – define connection (same project = no URL needed)
var con = $.hubConnection();

// Step 2 – create proxy for the hub named "chat"
prox = con.createHubProxy("chat");

// Step 3 – subscribe BEFORE starting the connection
prox.on("newMessage", function (n, m) {
    $("ul").append("<li>" + n + ": " + m + "</li>");
});

// Step 4 – start connection
con.start();
```

```js
// Call a server method
function send() {
    prox.invoke("sendMessage", name, $("#txt").val());
}
```

> ?? **Tip:** Always subscribe with `.on()` **before** calling `con.start()` — otherwise you may miss early messages.

---

## The Full Flow (Step by Step)

```
1. Page loads  ?  ask user for their name
2. Create connection & proxy
3. Subscribe to "newMessage" (what to do when server sends a message)
4. Start connection
5. User types a message and clicks Send
6. Client calls  prox.invoke("sendMessage", name, message)  ?  goes to server
7. Server receives it and calls  Clients.All.newMessage(name, message)  ?  goes to all clients
8. Each client's  prox.on("newMessage", ...)  runs  ?  message appears on screen
```

---

## Variable Scope Tip

```js
// Block scope – only available inside the $(function(){}) block
let prox = con.createHubProxy("chat");

// Global scope – available everywhere including the send() function
prox = con.createHubProxy("chat");
```

> ?? **Tip:** Use a global variable (no `let`/`const`) when you need to call the proxy from outside the `$(function(){})` block, like inside a `send()` function.

---

## Quick Reference Card

| What | Server (C#) | Client (JS) |
|---|---|---|
| Define hub | `class ChatHub : Hub` | `con.createHubProxy("chat")` |
| Call ALL clients | `Clients.All.methodName()` | — |
| Listen to server | — | `prox.on("methodName", fn)` |
| Call server | — | `prox.invoke("methodName", args)` |
| Start connection | `app.MapSignalR()` | `con.start()` |
