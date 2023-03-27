const mysql = require('mysql')

const conexion = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'unitydb'
})

conexion.connect((error)=>{
    if(error){
        console.log(error)
        return
    }
    console.log('¡Conected With the DB!')
})


module.exports = conexion