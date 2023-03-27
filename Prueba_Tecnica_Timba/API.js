const express = require ('express')
const connection = require ('./database')
const app = express();

app.use(express.json())

app.listen(3000, () => {
    console.log("Listening on port 3000...")
})

app.post('/createPlayer',(req,res)=>{
    const playerName = req.body.namePlayer;
    const playerScore = req.body.scorePlayer;
    if(playerName != undefined && playerScore != undefined){
        connection.query(`INSERT INTO players (namePlayer,scorePlayer) VALUES ('${playerName}','${playerScore}')`,(error,results)=>{
            if(error){
                console.log(error)
            }else if(results!=null){
                res.status(200).send(JSON.stringify(results["affectedRows"]))
            }else{
                res.status(404).send();
            }
            
        })
    }
})

app.get('/readAll', (req,res)=>{
    connection.query('SELECT * FROM players',(error,results)=>{
        if(error){
            console.log(error)
        }else if(results!=null){
            res.status(200).send(JSON.stringify(results))
        }else{
            console.log(results)
            res.status(404).send()
        }
    })
})