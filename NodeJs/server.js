var websocket = require('ws');

var websocketServer = new websocket.Server({port:25500}, ()=>{
	console.log("Server is runnung");
});

var wsList = [];

websocketServer.on("connection", (ws, rq)=>{

	console.log('client connected.');

    wsList.push(ws);
    
    ws.on("message" , (data)=>{
    
        console.log("send from clint : "+data);
        Boardcast(data);
    });
    
    ws.on("close", ()=>{

        wsList = ArrayRemove(wsList, ws);
        console.log("client disconnexted.");
    });

});

function ArrayRemove(arr, value)
{
    return arr.filter((element)=>{
        return element != value;
    });
}

function Boardcast(data)
{
    for(var i = 0; i < wsList.Length; i++)
    {
        wsList[i].send(data);
    }
}