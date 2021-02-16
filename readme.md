# GraphQL Demo Playground



## Subscriptions
Graphql not only exposes queries and mutations, but also subscriptions which leverages websockets to receive realtime updates from the server. Below you will find a sample subscription query as well as a mutation to add new chat messages so you can what the subscription events fire off.

_*To execute subscriptions in the playground you will need to leverage the Altair UI at `/ui/altair`_

### Query
```
subscription{
  messageAdded{
    content,
    from{
      displayName
    }
  }
}
```
### Mutation
```
mutation{
  addMessage(message:{
    fromId: "1222",
    content: "Hello world",
    sentAt: "2021-02-16"

  }){
    content
  }
}
```

You can also kick off multiple messages by calling
`/api/messagestream/toggle`
to stop the messages call the toggle endpoint again.
